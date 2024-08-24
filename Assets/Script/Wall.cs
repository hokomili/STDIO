using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="STDIO/Wall")]
public class Wall : ScriptableObject,ICollidible
{
    public TileBase tile;
    public void Collide(ICollidible collider)
    {
        Debug.Log("Collide!!!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
