using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float centertoborderxgrids=9f;
    float centertoborderygrids=5f;
    const int gridx=22;
    const int gridy=14;
    public GreadSystem theGread;
    public Transform Target;
    public Vector3 TargetPos=new();
    Vector3 offset;
    void Start()
    {
        offset=transform.position-Target.position;
    }
    void Update()
    {
        TargetPos=Target.position+offset;
        if(Target.position.x<9)TargetPos.x=9;
        if(Target.position.y<5)TargetPos.y=5;
        if(Target.position.x>gridx-centertoborderxgrids)TargetPos.x=gridx-centertoborderxgrids;
        if(Target.position.y>gridy-centertoborderygrids)TargetPos.y=gridy-centertoborderygrids;
        transform.position=TargetPos;
    }
}
