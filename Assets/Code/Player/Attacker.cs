using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    public delegate void OnAttackDelegate();
    public event OnAttackDelegate OnAttack;

    [SerializeField] private float _coolDown;

    private float _timer = 0;

    public Vector2 Direction { get; set; } = Vector2.right;

    protected abstract void AttackAction();

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_timer <= 0)
        {
            _timer = _coolDown;

            AttackAction();

            OnAttack?.Invoke();
        }
    }
}
