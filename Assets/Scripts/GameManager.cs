using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Definition
    public static GameManager S;

    public enum GameState { title, pause, scene, dead }

    [Header("Game State")]
    public GameState gameState;

    [Header("GameObjects")]
    public GameObject player;
    public GameObject rootsAttractor;
    public GameObject rootsDetractor;
    public List<GameObject> rootModels;

    [Header("Level References")]
    public BlackFade blackFade;
    public GameObject lastCheckpoint;

    [Header("Value Tracking")]
    public int ammoCount = 0;
    public int scoreCount = 0;

    [Header("UI References")]
    public TextMeshProUGUI rootsText;
    public TextMeshProUGUI seedsText;

    [HideInInspector]
    public GameObject rootsParent;

    private void Awake()
    {
        S = this;
    }

    void Start()
    {
        // Set dependencies
        rootsParent = new ("RootsParent");

        // Determine cursor lock
        if (LevelManager.S.cityScene) Cursor.lockState = CursorLockMode.Locked;

        // Set UI
        UpdateTextUI();
    }

    void Update()
    {
        
    }

    public void UpdateTextUI()
    {
        rootsText.SetText(ammoCount + "");
        seedsText.SetText(ammoCount + "");
    }
}
