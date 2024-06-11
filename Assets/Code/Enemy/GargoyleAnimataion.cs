using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
public class GargoyleAnimataion : MonoBehaviour
{
    private const string attackTrigger = "attack";
    private const string dieTrigger = "die";
    private const string hitTrigger = "hit";

    private Enemy _enemy;
    private Animator _animator;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();

        _enemy.Damageable.OnDamage += Damage;
        _enemy.OnDeath += Die;
        _enemy.Attacker.OnAttack += Attack;
    }

    private void Attack()
    {
        _animator.SetTrigger(attackTrigger);
    }

    private void Damage(float damage)
    {
        if (_enemy.IsDead)
        {
            return;
        }

        _animator.SetTrigger(hitTrigger);
    }

    private void Die()
    {
        _animator.SetTrigger(dieTrigger);
    }
}
