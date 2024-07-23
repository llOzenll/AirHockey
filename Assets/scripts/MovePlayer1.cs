using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer1 : MonoBehaviour
{
   public List<Move> Players = new();

   void Update(){

    for(int i = 0; i < Input.touchCount; i++){

        Vector2 touchWorldPosition =  Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

        foreach (var player in Players){

            if(player.LockedFingerID == null){

                if(Input.GetTouch(i).phase == TouchPhase.Began && player.PlayerCollider.OverlapPoint(touchWorldPosition)){

                    player.LockedFingerID = Input.GetTouch(i).fingerId;
                }

                else if(player.LockedFingerID == Input.GetTouch(i).fingerId){

                    player.MoveToPosition(touchWorldPosition);

                    if(Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled){

                        player.LockedFingerID = null;
                    }
                }
            }
            else if(player.LockedFingerID == Input.GetTouch(i).fingerId){

                    player.MoveToPosition(touchWorldPosition);

                    if(Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled){

                        player.LockedFingerID = null;
                    }
                }
        }
    }
   }
}
