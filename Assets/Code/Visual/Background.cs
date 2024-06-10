using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        transform.position = _target.position;
    }
}
