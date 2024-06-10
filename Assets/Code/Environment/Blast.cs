using UnityEngine;

public class Blast : MonoBehaviour
{
    private const float despawnDelay = 0.8f;
    private const float maxExcistingTime = 10.0f;

    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeath;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _power;
    [SerializeField] private float _speed;

    private bool _dead = false;

    private void Start()
    {
        Destroy(gameObject, maxExcistingTime);
    }

    private void Update()
    {
        if (_dead)
        {
            return;
        }

        transform.position += _speed * Time.deltaTime * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.layer & _layerMask.value) != 0)
        {
            return;
        }

        if(collision.TryGetComponent<Damageable>(out var damageable))
        {
            damageable.Damage(_power);
        }

        _dead = true;

        OnDeath?.Invoke();

        Destroy(gameObject, despawnDelay);
    }
}
