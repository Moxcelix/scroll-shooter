using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float _depth;

    private void FixedUpdate()
    {
        for(int i = 0; i < _layers.Length; i++)
        {
            var x = _target.position.x * 
                ((i + _depth) / (float)(_layers.Length - 1 + _depth));

            _layers[i].position = new Vector2(x, _target.position.y);
        }
    }
}
