using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DiskScript : MonoBehaviour
{
    public ScoreGame ScoreInstance;
    public static bool WasGoal {get; private set;}
    private Rigidbody2D DiskRb;

    public float maxSpeddDisk;

    void Start(){
        DiskRb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(!WasGoal){
            if(other.tag == "GoalAi"){
                ScoreInstance.Increment(ScoreGame.Score.ScorePlayer);
                WasGoal =true;
                StartCoroutine(ResetDiskPosition(false));
            }
            else if(other.tag == "GoalPlayer"){
                ScoreInstance.Increment(ScoreGame.Score.ScoreAi);
                WasGoal =true;
                StartCoroutine(ResetDiskPosition(true));
            }
        }
    }

    private IEnumerator ResetDiskPosition(bool AiScored){
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        DiskRb.velocity = DiskRb.position = new Vector2(0,0);

        if(AiScored) DiskRb.position = new Vector2(0.25f, -4.87f);
        else DiskRb.position = new Vector2(0.25f, 5.77f);
    }

    public void ResetDisk(){
        DiskRb.position = new Vector2(0, 0);
    }

    private void FixedUpdate(){
        DiskRb.velocity = Vector2.ClampMagnitude(DiskRb.velocity, maxSpeddDisk);
    }
}
