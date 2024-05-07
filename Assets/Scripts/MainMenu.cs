using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStartButton()
    {
        SceneManager.LoadScene("—цена с квестами(2)");
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
}
