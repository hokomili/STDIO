using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public static Snake instance;
    public Direction direction=Direction.North;
    public Vector2 TargetPosition=new(0.5f,0.5f);
    public List<Vector2> TargetPositions=new();
    public float LerpStrength=0.1f;
    public SnakeBody SnakeHead;
    public GreadSystem greadSystem;
    public List<SnakeBody> SnakeBodies; 
    public float MoveCooldown=1;
    float timer=0;
    public enum Direction{
        North,
        West,
        South,
        East
    }
    // Start is called before the first frame update
    void Start()
    {
        SnakeHead.gread=greadSystem.GetGread(TargetPosition.x,TargetPosition.y);
        SnakeHead.gread.collidible=SnakeHead;
        for(int i=SnakeBodies.Count-1;i>=0;i--){
            SnakeBodies[i].gread=greadSystem.GetGread(TargetPositions[i].x,TargetPositions[i].y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SnakeBodies.Count>0){
            if(Input.GetKeyDown(KeyCode.W)&&SnakeHead.gread.Up!=SnakeBodies[0].gread)direction=Direction.North;
            if(Input.GetKeyDown(KeyCode.A)&&SnakeHead.gread.Left!=SnakeBodies[0].gread)direction=Direction.West;
            if(Input.GetKeyDown(KeyCode.S)&&SnakeHead.gread.Down!=SnakeBodies[0].gread)direction=Direction.South;
            if(Input.GetKeyDown(KeyCode.D)&&SnakeHead.gread.Right!=SnakeBodies[0].gread)direction=Direction.East;
        }
        else{
            if(Input.GetKeyDown(KeyCode.W))direction=Direction.North;
            if(Input.GetKeyDown(KeyCode.A))direction=Direction.West;
            if(Input.GetKeyDown(KeyCode.S))direction=Direction.South;
            if(Input.GetKeyDown(KeyCode.D))direction=Direction.East;
        }
        
    }
    void FixedUpdate(){
        timer+=Time.deltaTime;
        if(timer>MoveCooldown){
            timer-=MoveCooldown;
            bool iscollided=false;
            if(direction==Direction.North&&SnakeHead.gread.Up.collidible!=null)iscollided=true;
            if(direction==Direction.West&&SnakeHead.gread.Left.collidible!=null)iscollided=true;
            if(direction==Direction.South&&SnakeHead.gread.Down.collidible!=null)iscollided=true;
            if(direction==Direction.East&&SnakeHead.gread.Right.collidible!=null)iscollided=true;
            if(!iscollided){
                for(int i=SnakeBodies.Count-1;i>=1;i--){
                    TargetPositions[i]=TargetPositions[i-1];
                    if(i==SnakeBodies.Count-1)SnakeBodies[i].gread.collidible=null;
                    SnakeBodies[i].gread=SnakeBodies[i-1].gread;
                    SnakeBodies[i].gread.collidible=SnakeBodies[i];
                }
                if(SnakeBodies.Count>0){
                    TargetPositions[0]=TargetPosition;
                    if(SnakeBodies.Count==1)SnakeBodies[0].gread.collidible=null;
                    SnakeBodies[0].gread=SnakeHead.gread;
                    SnakeBodies[0].gread.collidible=SnakeBodies[0];
                }
                switch (direction)
                {
                    case Direction.North:
                        TargetPosition+=Vector2.up*GreadSystem.BlockSize;
                        SnakeHead.gread=SnakeHead.gread.Up;
                        SnakeHead.gread.collidible=SnakeHead;
                    break;
                    case Direction.West:
                        TargetPosition+=Vector2.left*GreadSystem.BlockSize;
                        SnakeHead.gread=SnakeHead.gread.Left;
                        SnakeHead.gread.collidible=SnakeHead;
                    break;
                    case Direction.South:
                        TargetPosition+=Vector2.down*GreadSystem.BlockSize;
                        SnakeHead.gread=SnakeHead.gread.Down;
                        SnakeHead.gread.collidible=SnakeHead;
                    break;
                    case Direction.East:
                        TargetPosition+=Vector2.right*GreadSystem.BlockSize;
                        SnakeHead.gread=SnakeHead.gread.Right;
                        SnakeHead.gread.collidible=SnakeHead;
                    break;
                }
            }
            else{
                Debug.Log("Hit wall");
            }
        }
        for(int i=SnakeBodies.Count-1;i>=1;i--)
        {
            SnakeBodies[i].rb.position=Vector2.Lerp(SnakeBodies[i].rb.position,TargetPositions[i],LerpStrength*Time.deltaTime);
        }
        SnakeBodies[0].rb.position=Vector2.Lerp(SnakeBodies[0].rb.position,TargetPositions[0],LerpStrength*Time.deltaTime);
        SnakeHead.rb.position=Vector2.Lerp(SnakeHead.rb.position,TargetPosition,LerpStrength*Time.deltaTime);
    }
}
