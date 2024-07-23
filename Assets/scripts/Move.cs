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

//ManoloCode
// [SerializeField] private LayerMask Player;
// private Transform jugador;

//Moving to touch
// bool canMove;
// void Update()
// {

//     if (Input.GetMouseButtonDown(0)){
//         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//         if(PlayerCollider.OverlapPoint(mousePosition)) canMove = true;
            
//         else canMove = false;


//         if(canMove) PlayerRb.MovePosition(mousePosition);
//         else canMove = false;

//     }

//     if (Input.GetMouseButtonUp(0)) canMove = false;
// }

// private void OnMouseDrag()
// {
//     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//     if (canMove){ 
//         Vector2 clampedPlayer = new Vector2(Mathf.Clamp(mousePosition.x, playerBoundary.LeftLimit, playerBoundary.RightLimit),
//         Mathf.Clamp(mousePosition.y, playerBoundary.DownLimit, playerBoundary.UpLimit));

//         PlayerRb.MovePosition(clampedPlayer);
//     }
// }