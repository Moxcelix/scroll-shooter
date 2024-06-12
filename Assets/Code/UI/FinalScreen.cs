using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("score"))
        {
            return;
        }

        var score = PlayerPrefs.GetFloat("score");
        _scoreText.text = $"И набрал: {score:00.00} очков!".Replace(',', '.');
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
