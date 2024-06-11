using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Player : MonoBehaviour
{
    private Movable _movable;

    [SerializeField] private Attacker _attacker;

    public Attacker Attacker => _attacker;

    public bool IsGrounded => _movable.IsGrounded;

    public bool LeftMoving { get; set; }

    public bool RightMoving { get; set; }

    public bool Jumping { get; set; }

    public bool Attacking { get; set; }

    public bool Flip { get; set; }  

    private void Start()
    {
        _movable = GetComponent<Movable>();
    }

    private void Update()
    {
        _movable.LeftMoving = LeftMoving;
        _movable.RightMoving = RightMoving;
        _movable.Jumping = Jumping;

        if (Attacking)
        {
            _attacker.Attack();
        }

        _movable.Flip = Flip;
        _attacker.Direction = Flip ? 
            -transform.right :
            transform.right;
    }
}
