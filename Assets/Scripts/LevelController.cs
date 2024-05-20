using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var newSceneIndex = currentSceneIndex + 1;
        PlayerPrefs.SetInt("currentLevel", newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);
    }

    // Update is called once per frame
    //public void BackToMainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}

    //public void NewGame()
    //{
    //    PlayerPrefs.SetInt("currentlevel", 1);
    //    SceneManager.LoadScene(1);
    //}
    //public void LoadCurrentLevel()
    //{
    //    var currentLevel = PlayerPrefs.GetInt("currentLevel");
    //    SceneManager.LoadScene(currentLevel);
    //}
}
