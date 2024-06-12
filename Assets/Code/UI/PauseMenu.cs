using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public void Back()
    {
        _playerInput.Unpause();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
