using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGui;
    public GameObject gameGui;

    public Dialog gameDialog;
    public Dialog pauseDialog;

    public Image fireRateFilled;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI killedCoutingText;

    Dialog m_curDialog;

    public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGui(bool isShow)
    {
        if (gameGui)
            gameGui.SetActive(isShow);
        
        if (homeGui)
            homeGui.SetActive(!isShow);
        
    }

    public void UpdateTimer(string time)
    {
        if (timerText)
        {
            timerText.text = time;
        }
    }

    public void UpdateKilledCounting(int killed)
    {
        if (killedCoutingText)
        {
            killedCoutingText.text = "x" + killed.ToString(); //x100
        }
    }

    public void UpdateFireRate(float rate)
    {
        if (fireRateFilled)
            fireRateFilled.fillAmount = rate;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;

        if (pauseDialog)
        {
            pauseDialog.showDialog(true);
            pauseDialog.UpdateDialog("GAME PAUSE", "BEST KILLED : x" + Prefs.bestScore);
            m_curDialog = pauseDialog;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (m_curDialog)
            m_curDialog.showDialog(false);
    }

    public void BackToHome()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReplayGame()
    {
        if (m_curDialog)
            m_curDialog.showDialog(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GameManager.Ins.PlayGame();
    }
    public void ExitGame()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}


