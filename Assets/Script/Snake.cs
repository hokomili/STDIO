using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public static Snake instance;
    public Direction direction=Direction.North;
    public Vector2 TargetPosition=new(0.5f,0.5f);
    public List<Vector2> TargetPositions=new();
    public float BlockSize;
    public float LerpStrength=0.1f;
    public Rigidbody2D RB;
    public List<Rigidbody2D> RBs; 
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))direction=Direction.North;
        if(Input.GetKeyDown(KeyCode.A))direction=Direction.West;
        if(Input.GetKeyDown(KeyCode.S))direction=Direction.South;
        if(Input.GetKeyDown(KeyCode.D))direction=Direction.East;
    }
    void FixedUpdate(){
        timer+=Time.deltaTime;
        if(timer>MoveCooldown){
            timer-=MoveCooldown;
            for(int i=RBs.Count-1;i>=1;i--)
            {
                TargetPositions[i]=TargetPositions[i-1];
            }
            if(RBs.Count>0){
                TargetPositions[0]=TargetPosition;
            }
            switch (direction)
            {
                case Direction.North:
                    TargetPosition+=Vector2.up*BlockSize;
                break;
                case Direction.West:
                    TargetPosition+=Vector2.left*BlockSize;
                break;
                case Direction.South:
                    TargetPosition+=Vector2.down*BlockSize;
                break;
                case Direction.East:
                    TargetPosition+=Vector2.right*BlockSize;
                break;
            }
            
        }
        for(int i=RBs.Count-1;i>=1;i--)
        {
            RBs[i].position=Vector2.Lerp(RBs[i].position,TargetPositions[i],LerpStrength*Time.deltaTime);
        }
        RBs[0].position=Vector2.Lerp(RBs[0].position,TargetPositions[0],LerpStrength*Time.deltaTime);
        RB.position=Vector2.Lerp(RB.position,TargetPosition,LerpStrength*Time.deltaTime);
    }
}
