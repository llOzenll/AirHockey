using UnityEngine;

public class MoveAi : MonoBehaviour
{
    public float MaxSpeed;
    private Rigidbody2D AiRb;
    private Vector2 IniPosition;

    public Rigidbody2D Disk;

    public Transform AiBoundaryHolder;
    private Boundary AiBoundary;

    public Transform diskBoundaryHolder;
    private Boundary diskBoundary;

    private Vector2 DiskPosition;

    private bool IsInsideEnemy = true;
    private float OffSetX;

    private void Start()
    {
        AiRb = GetComponent<Rigidbody2D>();
        IniPosition = AiRb.position;

        AiBoundary = new Boundary(AiBoundaryHolder.GetChild(0).position.y, AiBoundaryHolder.GetChild(1).position.y,
        AiBoundaryHolder.GetChild(2).position.x, AiBoundaryHolder.GetChild(3).position.x);

        diskBoundary = new Boundary(diskBoundaryHolder.GetChild(0).position.y, diskBoundaryHolder.GetChild(1).position.y,
        diskBoundaryHolder.GetChild(2).position.x, diskBoundaryHolder.GetChild(3).position.x);
    }

    private void FixedUpdate(){

        if(!DiskScript.WasGoal){
        
            float speed;

            if(Disk.position.y < diskBoundary.DownLimit){

                if(IsInsideEnemy){
                    IsInsideEnemy = false;
                    OffSetX = Random.Range(-10f, 10f);
                }

                speed = MaxSpeed * Random.Range(0.3f, 0.6f);
                DiskPosition = new Vector2(Mathf.Clamp(Disk.position.x + OffSetX, AiBoundary.LeftLimit, AiBoundary.RightLimit), IniPosition.y);
            }
            else{

                IsInsideEnemy = true;

                speed = Random.Range(MaxSpeed * 1f, MaxSpeed);
                DiskPosition = new Vector2(Mathf.Clamp(Disk.position.x, AiBoundary.LeftLimit, AiBoundary.RightLimit),
                                            Mathf.Clamp(Disk.position.y, AiBoundary.DownLimit, AiBoundary.UpLimit));
            }

            AiRb.MovePosition(Vector2.MoveTowards(AiRb.position, DiskPosition, speed * Time.fixedDeltaTime));
        }
    }

    public void ResetPosition(){
        AiRb.position = IniPosition; 
    }
}
