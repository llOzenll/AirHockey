using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    [Header ("CanvasMenus")]
    public GameObject ScoreManager;
    public GameObject CanvasMenu;

    [Header ("CanvasTxt")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header ("Other")]
    // public AudioManager audioManager;

    public ScoreGame ScoreGame;

    public DiskScript diskScript;
    public Move move;
    public MoveAi moveAi;
    private bool IsAI;

    public void ShowRestartCanvas(bool AiWin){
        Time.timeScale = 0;

        ScoreManager.SetActive(false);
        CanvasMenu.SetActive(true);

        if(AiWin){
            // AudioManager.PlayLost();
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else{
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
    }

    
    
    public void Retry()
    {
        Time.timeScale = 1;

        ScoreManager.SetActive(true);
        CanvasMenu.SetActive(false);

        ScoreGame.ResetScores();
        diskScript.ResetDisk();
        move.ResetPosition();
        if(IsAI = PlayerPrefs.GetInt("IsAI") == 1){
            moveAi.ResetPosition();
        }else if(IsAI = PlayerPrefs.GetInt("IsAI") == 0){
            // Debug.Log("hola");
        }
    }

    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
