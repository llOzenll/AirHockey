using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D PlayerRb;
    Vector2 startingPosition;

    public Transform PlayerBoundaryHolder;
    Boundary playerBoundary;


    public MovePlayer1 Controller;
    public Collider2D PlayerCollider {get; private set;}
    public int? LockedFingerID { get; set;}

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        startingPosition = PlayerRb.position;

        PlayerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,PlayerBoundaryHolder.GetChild(1).position.y,
                                        PlayerBoundaryHolder.GetChild(2).position.x, PlayerBoundaryHolder.GetChild(3).position.x);
        
    }

    private void OnEnable(){
        Controller.Players.Add(this);
    }

    private void OnDisable(){
        Controller.Players.Remove(this);
    }
    public void MoveToPosition(Vector2 position){
        Vector2 clampedPlayer = new(Mathf.Clamp(position.x, playerBoundary.LeftLimit, playerBoundary.RightLimit),
                                 Mathf.Clamp(position.y, playerBoundary.DownLimit, playerBoundary.UpLimit));

        PlayerRb.MovePosition(clampedPlayer);
    }
    public void ResetPosition(){
        PlayerRb.position = startingPosition; 
    }
}