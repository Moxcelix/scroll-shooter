using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movable : MonoBehaviour
{
    private const float groundedMinDistance = .01f;
    private const float wallMinDistance = .1f;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _dampingSpeed;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private BoxCollider2D _bodyCollider;

    private Rigidbody2D _rigidbody;

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
        CheckGround();
        UpdateJumping();
        UpdateMoving(Time.fixedDeltaTime);
    }

    private void UpdateJumping()
    {
        if (IsGrounded && Jumping)
        {
            IsGrounded = false;

            _rigidbody.AddForce(_jumpForce * Vector2.up);
        }
    }

    private void UpdateMoving(float deltaTime)
    {
        var rightMove = RightMoving ? _speed : 0;
        var leftMove = LeftMoving ? _speed : 0;
        var move = rightMove - leftMove;
        var isTouchingWall = Physics2D.Raycast(
          _groundCheck.position,
          transform.right * Mathf.Sign(move),
          _bodyCollider.size.x * 0.5f + wallMinDistance,
          _whatIsGround);

        var moveHorizontal = Mathf.Lerp(
            _rigidbody.velocity.x, move,
            deltaTime * _dampingSpeed);

        if (isTouchingWall)
        {
            moveHorizontal = 0;
        }

        _rigidbody.velocity = new Vector2(
            moveHorizontal, _rigidbody.velocity.y);
    }

    private void CheckGround()
    {
        var colliders = Physics2D.OverlapCircleAll(
            _groundCheck.position, groundedMinDistance, _whatIsGround);

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
