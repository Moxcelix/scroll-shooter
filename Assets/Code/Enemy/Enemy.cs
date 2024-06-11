using UnityEngine;

[RequireComponent(typeof(Movable))]
[RequireComponent(typeof(Damageable))]
public class Enemy : MonoBehaviour
{
    private const float attackDistance = 2.0f;

    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeath;

    private const float maxHp = 10.0f;
    private const float despawnDelay = 1.5f;

    private Damageable _damageable;
    private Movable _movable;

    private Player _target = null;

    public bool IsDead { get; set; } = false;

    public Damageable Damageable => _damageable;

    public bool RightMoving => _movable.RightMoving;

    public bool LeftMoving => _movable.LeftMoving;

    public float HP { get; private set; } = maxHp;

    private void Awake()
    {
        _damageable = GetComponent<Damageable>();
        _movable = GetComponent<Movable>();

        _damageable.OnDamage += OnDamage;
    }

    private void Update()
    {
        _movable.Jumping = true;

        UpdateMoving();
    }

    private void OnDamage(float damage)
    {
        if (IsDead)
        {
            return;
        }

        HP -= damage;

        if (HP < 0)
        {
            IsDead = true;

            OnDeath?.Invoke();

            Destroy(gameObject, despawnDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out var player))
        {
            _target = player;
        }
    }

    private void UpdateMoving()
    {
        if(_target == null)
        {
            return;
        }

        if (IsDead)
        {
            return;
        }

        var isLeft = _target.transform.position.x - transform.position.x < 0;

        _movable.Flip = isLeft;

        var distance = Mathf.Abs(
            _target.transform.position.x -
            transform.position.x);

        Debug.Log(distance);

        if (distance < attackDistance)
        {
            _movable.RightMoving = false;
            _movable.LeftMoving = false;
        }
        else
        {
            _movable.RightMoving = !isLeft;
            _movable.LeftMoving = isLeft;
        }
    }
}
