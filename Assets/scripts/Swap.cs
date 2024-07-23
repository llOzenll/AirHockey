using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
  public Move Move;
  public MoveAi MoveAi;
  private bool IsAI;

  private void Start(){
    if(IsAI = PlayerPrefs.GetInt("IsAI") == 1){
        MoveAi.enabled =true;
        Move.enabled = false;
    }
    else if(IsAI = PlayerPrefs.GetInt("IsAI") == 0){
        MoveAi.enabled = false;
        Move.enabled = true;
    }
  }
}
