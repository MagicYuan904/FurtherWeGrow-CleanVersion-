using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{

    public enum FadeToggle { fadeIn, fadeOut }
    public FadeToggle fade;
    public float blackFadeRate = 0.01f;
    
    private Image blackImage;
    private bool sceneFadeIn = false;
    private bool sceneFadeOut = false;


    private void Start()
    {
        blackImage = GetComponent<Image>();
        if (fade == FadeToggle.fadeIn) sceneFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Start fade for title scene
        if (sceneFadeOut)
        {
            float newAlpha = UpdateFade();
            if (newAlpha >= 1f)
            {
                LevelManager.S.LoadNextScene();
            }
        }
        else if (sceneFadeIn)
        {
            float newAlpha = UpdateFade();
            if (newAlpha <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetFade()
    {
        blackImage = GetComponent<Image>();
        var tempColor = blackImage.color;
        tempColor.a = 1f;
        blackImage.color = tempColor;
    }

    public void FadeToNextScene()
    {
        sceneFadeOut = true;
    }

    private float UpdateFade()
    {
        var tempColor = blackImage.color;
        tempColor.a += blackFadeRate;
        blackImage.color = tempColor;

        return tempColor.a;
    }
}
