using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GreadSystem : MonoBehaviour{
    public Tilemap BackgroundTilemap;
    public Tilemap ForegroundTilemap;
    public static float BlockSize=1;
    public Wall wall1;
    public float startposx;
    public float startposy;
    public Gread[,] greads;
    public Gread GetGread(float x,float y){
        return greads[Mathf.RoundToInt((x-startposx)/BlockSize),Mathf.RoundToInt((y-startposy)/BlockSize)];
    }
    void Awake(){
        BackgroundTilemap.CompressBounds();
        ForegroundTilemap.CompressBounds();
        int x=BackgroundTilemap.cellBounds.xMax-BackgroundTilemap.cellBounds.xMin;
        int y=BackgroundTilemap.cellBounds.yMax-BackgroundTilemap.cellBounds.yMin;
        startposx=BackgroundTilemap.cellBounds.xMin+BlockSize*0.5f;
        startposy=BackgroundTilemap.cellBounds.yMin+BlockSize*0.5f;
        greads = new Gread[x,y];
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                greads[i,k]=new Gread(this,i*BlockSize+startposx,k*BlockSize+startposy);
                if(ForegroundTilemap.GetTile(new(i,k,0))==wall1.tile){
                    Debug.Log(i+","+k);
                    greads[i,k].collidible=wall1;
                }
            }
        }
    }
}
