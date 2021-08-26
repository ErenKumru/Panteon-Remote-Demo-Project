using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private TMP_Text playerRankingText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text paintPercentageText;
    [SerializeField] private GameObject inGameMenuPanel;
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    private InputManager inputManager;
    private LevelManager levelManager;
    private LevelInfoManager levelInfoManager;
    private AudioManager audioManager;
    private PaintableController paintableController;
    private bool paintStarted = false;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        levelManager = FindObjectOfType<LevelManager>();
        levelInfoManager = FindObjectOfType<LevelInfoManager>();
        audioManager = FindObjectOfType<AudioManager>();
        paintableController = FindObjectOfType<PaintableController>();
    }

    private void Start()
    {
        ShowLevel();
    }

    private void Update()
    {
        if (paintStarted) ShowPaintedAreaPercentage();
        else ShowPlayerRanking();
    }

    private void ShowLevel()
    {
        levelText.text = "Level " + levelManager.GetLevel().ToString();
    }

    private void ShowPlayerRanking()
    {
        playerRankingText.text = (levelInfoManager.GetPlayerRanking() + 1).ToString() + " / " + levelInfoManager.GetTotalNumberOfCharacters();
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        inputManager.enabled = false;
        inGameMenuPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        inGameMenuPanel.SetActive(false);
        inputManager.enabled = true;
        Time.timeScale = 1; 
    }

    public void HandleSoundButtonClick()
    {
        bool muted = audioManager.MuteUnmuteSound();
        soundButtonImage.sprite = muted ? soundOffSprite : soundOnSprite;
    }

    public void ToggleMenuButton()
    {
        menuButton.SetActive(!menuButton.activeSelf);
    }

    public void StartPaintText()
    {
        levelText.enabled = false;
        playerRankingText.enabled = false;
        paintPercentageText.enabled = true;
        paintStarted = true;
    }

    private void ShowPaintedAreaPercentage()
    {
        paintPercentageText.text = paintableController.GetPaintedPercentage().ToString("00.00") + " % 100";
    }
}
