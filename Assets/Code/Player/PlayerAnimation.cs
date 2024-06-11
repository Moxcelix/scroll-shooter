using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    private const string walkingBool = "walking";
    private const string jumpingBool = "jumping";
    private const string attackTrigger = "attack";
    private const string dieTrigger = "die";
    private const string hitTrigger = "hit";

    private Animator _animator;
    private Player _player;

    private bool _isJumpingAnim = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();

        _player.Attacker.OnAttack += OnAttack;
        _player.Damageable.OnDamage += OnDamage;
    }

    private void OnDamage(float damage)
    {
        _animator.SetTrigger(hitTrigger);
    }

    private void Update()
    {
        if (_player.Jumping)
        {
            _isJumpingAnim = true;
        }

        if (_player.IsGrounded)
        {
            _isJumpingAnim = false;
        }

        _animator.SetBool(walkingBool, _player.LeftMoving | _player.RightMoving);
        _animator.SetBool(jumpingBool, _isJumpingAnim);
    }

    private void OnAttack()
    {
        _animator.SetTrigger(attackTrigger);
    }
}
