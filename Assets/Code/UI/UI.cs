using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Text _hpText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _manaText;
    [SerializeField] private Text _hintText;

    private void Update()
    {
        ShowStats();
        ShowHint();
    }

    private void ShowStats()
    {
        _hpText.text = $"HP: {_player.HP:00.00}".Replace(',', '.');
        _manaText.text = $"Mana: {_player.Mana:00.00}".Replace(',', '.');
        _scoreText.text = $"Score: {_player.Score:00.00}".Replace(',', '.');
    }

    private void ShowHint()
    {
        if (_player.Reloading)
        {
            _hintText.color = Color.yellow;
            _hintText.text = "Накопление маны...";
        }
        else if(_player.Mana <= 0)
        {
            _hintText.color = Color.red;
            _hintText.text = "Нажмите [R], чтобы накопить маны";
        }
        else
        {
            _hintText.text = string.Empty;
        }
    }
}
