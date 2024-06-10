using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movable : MonoBehaviour
{
    const float groundedRadius = .2f;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;

    private Rigidbody2D _rigidbody;
    private Vector3 _moveVelocity;

    public bool IsGrounded { get; private set; }

    public bool RightMoving { get; set; }

    public bool LeftMoving { get; set; }

    public bool Jumping { get; set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateJumping(Time.fixedDeltaTime);
        UpdateMoving(Time.fixedDeltaTime);
        CheckGround();

        _rigidbody.MovePosition(
            transform.position + _moveVelocity * Time.fixedDeltaTime);
    }

    private void UpdateJumping(float deltaTime)
    {
        if (IsGrounded)
        {
            _moveVelocity.y = Jumping ? _jumpSpeed : 0;
        }
        else
        {
            _moveVelocity += Physics.gravity * deltaTime;
        }
    }

    private void UpdateMoving(float deltaTime)
    {
        var rightMove = RightMoving ? _speed : 0;
        var leftMove = RightMoving ? _speed : 0;

        var move = rightMove - leftMove;

        _moveVelocity.x = Mathf.Lerp(_moveVelocity.x, move, deltaTime);
    }

    private void CheckGround()
    {    
        var colliders = Physics2D.OverlapCircleAll(
            _groundCheck.position, groundedRadius, _whatIsGround);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                IsGrounded = true;

                return;
            }
        }

        IsGrounded = false;
    }
}
