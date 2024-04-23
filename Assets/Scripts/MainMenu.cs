using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
}
