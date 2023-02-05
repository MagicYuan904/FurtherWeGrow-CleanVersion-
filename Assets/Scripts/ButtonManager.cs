using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Title Scene Panels")]
    public GameObject infoPanel;
    public GameObject creditsPanel;
    public GameObject blackPanel;

    private BlackFade blackFade;


    private void Start()
    {
        if (blackPanel)
        {
            blackFade = blackPanel.GetComponent<BlackFade>();
        }
    }

    public void btn_StartTheGame()
    {
        Debug.Log("Starting Game");
        blackPanel.SetActive(true);
        blackFade.FadeToNextScene();
    }

    public void btn_Quitgame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void btn_Info()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
        creditsPanel.SetActive(false);
    }

    public void btn_Credits()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        infoPanel.SetActive(false);
    }

    public void btn_NextScene()
    {
        Debug.Log("New scene");
        blackPanel.SetActive(true);
        blackFade.FadeToNextScene();
    }

    public void btn_NextLevel()
    {

    }

    public void btn_ReturnMainMenu()
    {
        LevelManager.S.ReturnToMainMenu();
    }
}