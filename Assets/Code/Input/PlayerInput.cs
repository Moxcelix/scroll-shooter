using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _jumpKey = KeyCode.W;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;

    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _player.RightMoving = Input.GetKey(_rightKey);
        _player.LeftMoving = Input.GetKey(_leftKey);
        _player.Jumping = Input.GetKey(_jumpKey);
        _player.Attacking = Input.GetMouseButton(0);
        _player.Flip = mousePos.x < _player.transform.position.x;

        if (Input.GetKeyDown(_reloadKey))
        {
            _player.Reload();
        }
    }
}
