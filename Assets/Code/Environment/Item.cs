using UnityEngine;

public class Item : MonoBehaviour
{
    public delegate void OnPickupDelegate(Player player);
    public event OnPickupDelegate OnPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            OnPickup?.Invoke(player);

            Destroy(gameObject);
        }
    }
}
