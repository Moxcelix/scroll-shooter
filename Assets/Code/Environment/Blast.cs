using UnityEngine;

public class Blast : MonoBehaviour
{
    private const float despawnDelay = 0.8f;

    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeath;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _power;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Damageable>(out var damageable))
        {
            damageable.Damage(_power);
        }

        Destroy(gameObject, despawnDelay);
    }
}
