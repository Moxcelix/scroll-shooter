using UnityEngine;

[RequireComponent(typeof(Movable))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Movable _movable;
    private Animator _animator;

    private const string walkingBool = "walking";
    private const string jumpingBool = "jumping";
    private const string attackTrigger = "attack";
    private const string dieTrigger = "die";
    private const string hitTrigger = "hit";

    private bool _isJumpingAnim = false;

    public bool LeftMoving { get; set; }

    public bool RightMoving { get; set; }

    public bool Jumping { get; set; }

    public bool Attacking { get; set; }

    private void Start()
    {
        _movable = GetComponent<Movable>();
        _animator = GetComponent<Animator>();
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

        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        if (_movable.Jumping)
        {
            _isJumpingAnim = true;
        }

        if (_movable.IsGrounded)
        {
            _isJumpingAnim = false;
        }
    }

    private void Attack()
    {
        _animator.SetTrigger(attackTrigger);
    }

    private void UpdateAnimator()
    {
        _animator.SetBool(walkingBool, _movable.LeftMoving | _movable.RightMoving);
        _animator.SetBool(jumpingBool, _isJumpingAnim);
    }
}
