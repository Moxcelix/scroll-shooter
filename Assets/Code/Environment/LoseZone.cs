using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private Level _level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            _level.Lose();
        }
    }
}
