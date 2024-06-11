using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Text _hpText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _manaText;

    private void Update()
    {
        _hpText.text = $"HP: {_player.HP:00.00}".Replace(',', '.');
        _manaText.text = $"Mana: {_player.Mana:00.00}".Replace(',', '.');
    }
}
