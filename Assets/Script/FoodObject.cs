using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodObject : MonoBehaviour, ICollectable
{
    public Gread mygread;
    public Food FoodType;
    public SpriteRenderer FoodImage;
    public void Collect()
    {
        SnakeStore.Feed(FoodType);
        mygread.collectable=null;
        Destroy(gameObject);
    }
}
