using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="STDIO/Food")]
public class Food : ScriptableObject
{
    public Sprite FoodSprite;
    public Color FoodColor;
    public string FoodName;
    [TextArea(1,4)]
    public string FoodInfo;
}
