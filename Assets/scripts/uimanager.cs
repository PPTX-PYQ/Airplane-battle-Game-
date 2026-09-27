using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    private static uimanager _instance;
    public static uimanager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<uimanager>();
            }
            return _instance;
        }
    }

    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI bombCountTMP;

    public Button pauseButton;
    public Button resumeButton;

    public GameObject gameOverPanel;
    public TextMeshProUGUI bestScoreTMP;
    public TextMeshProUGUI currentScoreTMP;

    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    private void Start()
    {
        pauseButton.onClick.RemoveListener(this.OnPauseButtonClick); 
        resumeButton.onClick.RemoveListener(this.OnResumeButtonClick);
        pauseButton.onClick.AddListener(this.OnPauseButtonClick);
        resumeButton.onClick.AddListener(this.OnResumeButtonClick);

        restartButton.onClick.RemoveListener(this.OnRestartButtonClick);
        quitButton.onClick.RemoveListener(this.OnQuitButtonClick);
        restartButton.onClick.AddListener(this.OnRestartButtonClick);
        quitButton.onClick.AddListener(this.OnQuitButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreUI(int score)
    {
        this.scoreTMP.text = score + "";
    }
    public void UpdateBombCountUI(int count)
    {
        this.bombCountTMP.text = count + "";
    }

    void OnPauseButtonClick()
    {
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        gamemanager.Instance.PauseGame();
        audiomanager.Instance.PlayButtonClip();
    }
    void OnResumeButtonClick()
    {
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        gamemanager.Instance.ResumeGame();
        audiomanager.Instance.PlayButtonClip();
    }

    public void ShowGameOverPanel(int bestScore, int currentScore)
    {
        gameOverPanel.SetActive(true);
        this.bestScoreTMP.text = bestScore + "";
        this.currentScoreTMP.text = currentScore + "";
    }

    void OnRestartButtonClick()
    {
        gamemanager.Instance.RestartGame();
        audiomanager.Instance.PlayButtonClip();
    }
    void OnQuitButtonClick()
    {
        gamemanager.Instance.QuitGame();
        audiomanager.Instance.PlayButtonClip();
    }
}
