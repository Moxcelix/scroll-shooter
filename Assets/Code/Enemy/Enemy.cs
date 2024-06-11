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

    public bool IsDead { get; set; } = false;

    public Damageable Damageable => _damageable;

    public float HP { get; private set; } = maxHp;

    private void Awake()
    {
        _damageable = GetComponent<Damageable>();
        _movable = GetComponent<Movable>();

        _damageable.OnDamage += OnDamage;
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
}
