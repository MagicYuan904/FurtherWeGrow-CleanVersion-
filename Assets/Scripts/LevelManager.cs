using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager S;

    [Header("Level Info")]
    public string levelName; // string to display at level start

    private string[] sceneNames = { "Title", "City", "End" };

    [Header("Scene Info")]
    public string nextScene; // string of level name
    public bool titleScene;
    public bool cityScene;
    public bool endScene; // end of game


    private void Awake()
    {
        S = this;
    }

    private void Start()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void RestartLevel()
    {
        // reload this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
