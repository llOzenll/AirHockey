using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    [Header ("CanvasMenus")]
    public GameObject CanvasMain;
    public GameObject CanvasPlayOptions;
    public GameObject CanvasRestart;
    public GameObject ScoreManager;

    [Header ("CanvasTxt")]
    public GameObject RedWins;
    public GameObject BlueWins;
    public GameObject GoalBlue;
    public GameObject GoalRed;

    [Header ("Other")]

    public ScoreGame ScoreGame;

    public DiskScript diskScript;
    public Move move;
    public MoveAi moveAi;




    private void Start()
    {
        Time.timeScale = 0;
    }


    public void ShowRestartCanvas(bool AiWin){

        ScoreManager.SetActive(false);
        CanvasRestart.SetActive(true);

        if(AiWin){
            // AudioManager.PlayLost();
            RedWins.SetActive(true);
            BlueWins.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            RedWins.SetActive(false);
            BlueWins.SetActive(true);
            Time.timeScale = 0;
        }
    }




    public void Restart()
    {

        ScoreManager.SetActive(true);
        CanvasRestart.SetActive(false);
        GoalBlue.SetActive(false);
        GoalRed.SetActive(false);

        ScoreGame.ResetScores();
        diskScript.ResetDisk();
        move.ResetPosition();
        if (moveAi != null)
        {
            moveAi.ResetPosition();
        }
    }


    public void Play()
    {
        CanvasPlayOptions.SetActive(true);
        CanvasMain.SetActive(false);

        GoalBlue.SetActive(false);
        GoalRed.SetActive(false);

        ScoreGame.ResetScores();
        move.ResetPosition();

        if (moveAi != null)
        {
            moveAi.ResetPosition();
        }
    }


    public void PlayVsAI()
    {
        Time.timeScale = 1;
        moveAi.enabled = true;
        move.enabled = true;

        ScoreManager.SetActive(true);
        CanvasPlayOptions.SetActive(false );

        ScoreGame.ResetScores();

    }
    public void PlayVsPlayer()
    {
        Time.timeScale = 1;
        moveAi.enabled = false;
        move.enabled = true;

        ScoreManager.SetActive(true);
        CanvasPlayOptions.SetActive(false);
        ScoreGame.ResetScores();
    }

    public void Back()
    {
        CanvasMain.SetActive(true);
        CanvasPlayOptions.SetActive(false);
        CanvasRestart.SetActive(false);
        ScoreManager.SetActive(false);
        GoalBlue.SetActive(false);
        GoalRed.SetActive(false);

        ScoreGame.ResetScores();
        move.ResetPosition();

        if (moveAi != null)
        {
            moveAi.ResetPosition();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
