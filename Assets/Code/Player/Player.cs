using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Player : MonoBehaviour
{
    private Movable _movable;

    private void Start()
    {
        _movable = GetComponent<Movable>();
    }

    private void Update()
    {
        _movable.LeftMoving = Input.GetKey(KeyCode.A);
        _movable.RightMoving = Input.GetKey(KeyCode.D);
        _movable.Jumping = Input.GetKey(KeyCode.W);
    }
}
