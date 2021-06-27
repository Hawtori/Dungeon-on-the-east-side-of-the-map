using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    private void Update()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.SetString("startHealth", "newStart");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
