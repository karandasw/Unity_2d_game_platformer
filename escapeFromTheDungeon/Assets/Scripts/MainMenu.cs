using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }

    public void ExitGame()
    {
        Debug.Log("game over");
        Application.Quit();
    }
}
