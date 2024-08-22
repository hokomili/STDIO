using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreadSystem : MonoBehaviour{
    public static float BlockSize=1;
    public int height;
    public int width;
    public float startposx;
    public float startposy;
    public Gread[,] greads;
    public Gread GetGread(float x,float y){
        return greads[Mathf.RoundToInt((x-startposx)/BlockSize),Mathf.RoundToInt((y-startposy)/BlockSize)];
    }
    void Awake(){
        greads = new Gread[width,height];
        for (int i = 0; i < width; i++)
        {
            for (int k = 0; k < height; k++)
            {
                greads[i,k]=new Gread(this,i*BlockSize+startposx,k*BlockSize+startposy);
            }
        }
    }
}
