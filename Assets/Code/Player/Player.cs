using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movable))]
[RequireComponent(typeof(Damageable))]
public class Player : MonoBehaviour
{
    private const float maxHp = 10.0f;
    private const float maxMana = 10.0f;

    private readonly WaitForSeconds _reloadDelay = new (3.0f);

    private Movable _movable;
    private Damageable _damageable;

    [SerializeField] private Attacker _attacker;

    [SerializeField] private float _manaConsumption; 

    public Attacker Attacker => _attacker;

    public float HP { get; private set; } = maxHp;

    public float Mana { get; private set; } = maxMana;

    public bool Reloading { get; private set; } = false;

    public bool IsGrounded => _movable.IsGrounded;

    public bool LeftMoving { get; set; }

    public bool RightMoving { get; set; }

    public bool Jumping { get; set; }

    public bool Attacking { get; set; }

    public bool Flip { get; set; }  

    private void Start()
    {
        _movable = GetComponent<Movable>();
        _damageable = GetComponent<Damageable>();

        _damageable.OnDamage += TakeDamage;
        _attacker.OnAttack += TakeMana;
    }

    private void Update()
    {
        _movable.LeftMoving = LeftMoving;
        _movable.RightMoving = RightMoving;
        _movable.Jumping = Jumping;

        if (Attacking)
        {
            Attack();
        }

        _movable.Flip = Flip;
        _attacker.Direction = Flip ? 
            -transform.right :
            transform.right;
    }

    public void Reload()
    {
        if(Mana > 0)
        {
            return;
        }

        StartCoroutine(ReloadCycle());
    }

    private IEnumerator ReloadCycle()
    {
        Reloading = true;

        yield return _reloadDelay;

        Mana = maxMana;

        Reloading = false;
    }

    private void Attack()
    {
        if(Mana <= 0)
        {
            Mana = 0;

            return;
        }

        _attacker.Attack();
    }

    private void TakeDamage(float damage)
    {
        HP -= damage;
    }

    private void TakeMana()
    {
        Mana -= _manaConsumption;
    }
}
