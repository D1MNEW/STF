using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStartButton()
    {
        SceneManager.LoadScene("����� � ��������(2)");
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
}
