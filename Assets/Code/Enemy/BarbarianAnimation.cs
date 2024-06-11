using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
public class BarbarianAnimation : MonoBehaviour
{
    private const string walkingBool = "walking";
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

    private void Update()
    {
        _animator.SetBool(walkingBool, _enemy.LeftMoving |  _enemy.RightMoving);
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
