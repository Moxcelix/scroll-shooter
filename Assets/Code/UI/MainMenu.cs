using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene(1);
    }

    public void Close()
    {
        Application.Quit();
    }
}
