using UnityEngine;

[RequireComponent(typeof(Movable))]
[RequireComponent(typeof(Damageable))]
public class Enemy : MonoBehaviour
{
    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeath;

    [SerializeField] private float _attackDistance = 2.5f;
    [SerializeField] private float _minDistance = 2.0f;
    [SerializeField] private Attacker _attacker;

    private const float maxHp = 10.0f;
    private const float despawnDelay = 1.5f;

    private Damageable _damageable;
    private Movable _movable;

    private Player _target = null;

    public bool IsDead { get; set; } = false;

    public Damageable Damageable => _damageable;

    public Attacker Attacker => _attacker;

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
        if (IsDead)
        {
            _movable.Jumping = false;
            _movable.RightMoving = false;
            _movable.LeftMoving = false;

            return;
        }

        _movable.Jumping = true;

        _attacker.Direction = _movable.Flip ?
            -transform.right :
            transform.right;

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

        var isLeft = _target.transform.position.x - transform.position.x < 0;

        _movable.Flip = isLeft;

        var distance = Mathf.Abs(
            _target.transform.position.x -
            transform.position.x);

        Debug.Log(distance);

        if (distance < _minDistance)
        {
            _movable.RightMoving = isLeft;
            _movable.LeftMoving = !isLeft;
        }
        else if(distance < _attackDistance)
        {
            _movable.RightMoving = false;
            _movable.LeftMoving = false;

            _attacker.Attack();
        }
        else
        {
            _movable.RightMoving = !isLeft;
            _movable.LeftMoving = isLeft;
        }
    }
}
