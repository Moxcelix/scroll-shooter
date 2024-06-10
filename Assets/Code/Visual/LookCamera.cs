using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private const float cameraDepth = -10.0f;

    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;


    private void FixedUpdate()
    {
        var targetPosition = new Vector3(
            _target.position.x, _target.position.y, cameraDepth);
        var currentPosition = new Vector3(
            transform.position.x, transform.position.y, cameraDepth);
        transform.position = Vector3.Lerp(
            currentPosition,
            targetPosition,
            _followSpeed * Time.fixedDeltaTime);
    }
}
