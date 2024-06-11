using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private float _enemyBonus = 3.5f;
    [SerializeField] private float _coinBonus = 1.0f;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Player _player;

    private void Start()
    {
        foreach(var enemy in _enemies)
        {
            enemy.OnDeath += Enemy_OnDeath;
        }
    }

    private void Enemy_OnDeath()
    {
        _player.AddScore(_enemyBonus);
    }
}
