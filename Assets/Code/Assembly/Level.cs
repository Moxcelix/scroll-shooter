using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float _enemyBonus = 3.5f;
    [SerializeField] private float _coinBonus = 1.0f;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Player _player;
    [SerializeField] private Item[] _hills;
    [SerializeField] private Item[] _coins;

    private void Start()
    {
        foreach (var enemy in _enemies)
        {
            enemy.OnDeath += Enemy_OnDeath;
        }

        foreach (var item in _coins)
        {
            item.OnPickup += Coin_OnPickup;
        }

        foreach (var item in _hills)
        {
            item.OnPickup += Hill_OnPickup;
        }
    }

    private void Update()
    {
        if (_player.IsDead)
        {
            PlayerPrefs.SetFloat("score", _player.Score);
            SceneManager.LoadScene(2);
        }
    }

    public void Win()
    {
        PlayerPrefs.SetFloat("score", _player.Score);
        SceneManager.LoadScene(3);
    }

    public void Lose()
    {
        PlayerPrefs.SetFloat("score", _player.Score);
        SceneManager.LoadScene(2);
    }

    private void Hill_OnPickup(Player player)
    {
        player.Hill();
    }

    private void Coin_OnPickup(Player player)
    {
        player.AddScore(_coinBonus);
    }

    private void Enemy_OnDeath()
    {
        _player.AddScore(_enemyBonus);
    }
}
