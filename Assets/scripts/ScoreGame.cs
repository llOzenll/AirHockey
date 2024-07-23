using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour
{
    public enum Score
    {
        ScoreAi, ScorePlayer
    }
    public TextMeshProUGUI ScoreAiTxt, ScorePlayerTxt;
    private int Scoreai, Scoreplayer;


#region limitScore
    public MenuManager menuManager;
    public int MaxScore;
    
    private int ScoreAi{
        get { return Scoreai;}
        set{ 
            Scoreai = value;
            if(value == MaxScore){
                menuManager.ShowRestartCanvas(true);
            }
        }
    }
    private int ScorePlayer{
        get { return Scoreplayer;}
        set{ 
            Scoreplayer = value;
            if(value == MaxScore){
                menuManager.ShowRestartCanvas(false);
            }
        }
    }
#endregion


    public void Increment(Score wichScore){
        
        if(wichScore == Score.ScoreAi)  ScoreAiTxt.text = (++ScoreAi).ToString();
           
        else ScorePlayerTxt.text = (++ScorePlayer).ToString();
    }

    public void ResetScores(){
        ScoreAi = ScorePlayer = 0;
        ScoreAiTxt.text = ScorePlayerTxt.text = "0";
    }
}