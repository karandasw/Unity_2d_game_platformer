using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    //load next level of dungeon
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") 
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel() 
    {
        //add load delay
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        //get current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //change scene index
        int nextSceneIndex = currentSceneIndex + 1;

        //reset scene index if next scene index ended
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0;
        }

        //load scene
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
