using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public static Snake instance;
    public Direction lastDirection=Direction.North;
    public Dictionary<Direction,float>Movingtimer=new();
    public Vector2 TargetPosition=new(0.5f,0.5f);
    public List<Vector2> TargetPositions=new();
    public float LerpStrength=0.1f;
    public SnakeBody SnakeHead;
    public GreadSystem greadSystem;
    public List<SnakeBody> SnakeBodies; 
    public float AutoMoveCooldown=1;
    public float ManualCooldown=0.5f;
    float autoMovingTimer=0;
    public Vector2 DirectionToVec(Direction direction){
        switch (direction)
        {
            case Direction.North:
            return Vector2.up;
            case Direction.South:
            return Vector2.down;
            case Direction.West:
            return Vector2.left;
            case Direction.East:
            return Vector2.right;
            default:
            return Vector2.up;
        }
    }
    public enum Direction{
        North,
        West,
        South,
        East
    }
    // Start is called before the first frame update
    void Start()
    {
        Movingtimer.Add(Direction.North,0);
        Movingtimer.Add(Direction.South,0);
        Movingtimer.Add(Direction.East,0);
        Movingtimer.Add(Direction.West,0);
        SnakeHead.gread=greadSystem.GetGread(TargetPosition.x,TargetPosition.y);
        SnakeHead.gread.collidible=SnakeHead;
        for(int i=SnakeBodies.Count-1;i>=0;i--){
            SnakeBodies[i].gread=greadSystem.GetGread(TargetPositions[i].x,TargetPositions[i].y);
        }
    }
    public void ManualMove(Direction direction){
        if(Movingtimer[direction]>ManualCooldown){
            Movingtimer[direction]-=ManualCooldown;
            autoMovingTimer=0;
            AutoMove(direction);
            lastDirection=direction;
        }
    }
    public void AutoMove(Direction direction){
        if(SnakeHead.gread.GetGread(direction).collidible!=null){
            SnakeHead.gread.GetGread(direction).collidible.Collide(SnakeHead);
        }
        else{
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
            TargetPosition+=DirectionToVec(direction)*GreadSystem.BlockSize;
            SnakeHead.gread=SnakeHead.gread.GetGread(direction);
            SnakeHead.gread.collidible=SnakeHead;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            if(SnakeBodies.Count==0||(SnakeBodies.Count>0&&SnakeHead.gread.Up!=SnakeBodies[0].gread))ManualMove(Direction.North);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            if(SnakeBodies.Count==0||(SnakeBodies.Count>0&&SnakeHead.gread.Left!=SnakeBodies[0].gread))ManualMove(Direction.West);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            if(SnakeBodies.Count==0||(SnakeBodies.Count>0&&SnakeHead.gread.Down!=SnakeBodies[0].gread))ManualMove(Direction.South);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            if(SnakeBodies.Count==0||(SnakeBodies.Count>0&&SnakeHead.gread.Right!=SnakeBodies[0].gread))ManualMove(Direction.East);
        }
        
    }
    void FixedUpdate(){
        autoMovingTimer+=Time.deltaTime;
        if(Movingtimer[Direction.North]<ManualCooldown)Movingtimer[Direction.North]+=Time.deltaTime;
        if(Movingtimer[Direction.West]<ManualCooldown)Movingtimer[Direction.West]+=Time.deltaTime;
        if(Movingtimer[Direction.South]<ManualCooldown)Movingtimer[Direction.South]+=Time.deltaTime;
        if(Movingtimer[Direction.East]<ManualCooldown)Movingtimer[Direction.East]+=Time.deltaTime;
        if(autoMovingTimer>AutoMoveCooldown){
            autoMovingTimer-=AutoMoveCooldown;
            AutoMove(lastDirection);
        }
        for(int i=SnakeBodies.Count-1;i>=1;i--)
        {
            SnakeBodies[i].rb.position=Vector2.Lerp(SnakeBodies[i].rb.position,TargetPositions[i],LerpStrength*Time.deltaTime);
        }
        SnakeBodies[0].rb.position=Vector2.Lerp(SnakeBodies[0].rb.position,TargetPositions[0],LerpStrength*Time.deltaTime);
        SnakeHead.rb.position=Vector2.Lerp(SnakeHead.rb.position,TargetPosition,LerpStrength*Time.deltaTime);
    }
}
