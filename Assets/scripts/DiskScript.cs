using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DiskScript : MonoBehaviour
{
    public ScoreGame ScoreInstance;
    public static bool WasGoal {get; private set;}
    private Rigidbody2D DiskRb;

    public Move Disk;
    public Move Disk1;
    public MoveAi DiskAI;

    public GameObject GoalBlue;
    public GameObject GoalRed;
    public float maxSpeddDisk;

    void Start(){
        DiskRb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Trigger(other));
    }

    IEnumerator Trigger(Collider2D other){
        if(!WasGoal){
            if(other.CompareTag("GoalAi")){
                ScoreInstance.Increment(ScoreGame.Score.ScorePlayer);
                WasGoal =true;
                GoalBlue.SetActive(true);
                Time.timeScale = 0;

                yield return new WaitForSecondsRealtime(1f);

                Time.timeScale = 1;
                Disk.ResetPosition();
                Disk1.ResetPosition();
                ResetDiskPosition(false);

                if (DiskAI.enabled == true)  DiskAI.ResetPosition();
                    
                GoalBlue.SetActive(false);

            }
            else if(other.CompareTag("GoalPlayer")){
                ScoreInstance.Increment(ScoreGame.Score.ScoreAi);
                WasGoal =true;
                GoalRed.SetActive(true);
                Time.timeScale = 0;

                yield return new WaitForSecondsRealtime(1f);

                Time.timeScale = 1;
                Disk.ResetPosition();
                Disk1.ResetPosition();
                ResetDiskPosition(true);

                if (DiskAI.enabled == true) DiskAI.ResetPosition();
                    
                GoalRed.SetActive(false);
            }
        }
    }

    private void ResetDiskPosition(bool AiScored){
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
