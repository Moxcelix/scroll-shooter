using UnityEngine;

[RequireComponent(typeof(Movable))]
[RequireComponent(typeof(Damageable))]
public class Enemy : MonoBehaviour
{
    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeath;

    private const float maxHp = 10.0f;
    private const float despawnDelay = 1.5f;

    private Damageable _damageable;
    private Movable _movable;

    private bool _isDead = false;

    public float HP { get; private set; } = maxHp;

    private void Start()
    {
        _damageable = GetComponent<Damageable>();
        _movable = GetComponent<Movable>();

        _damageable.OnDamage += OnDamage;
    }

    private void OnDamage(float damage)
    {
        if (_isDead)
        {
            return;
        }

        HP -= damage;

        if (HP < 0)
        {
            _isDead = true;

            OnDeath?.Invoke();

            Destroy(gameObject, despawnDelay);
        }
    }
}
