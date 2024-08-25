using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPanel : MonoBehaviour
{
    public static FoodPanel instance;
    public Image Food1;
    public Image Food2;
    public Image Food3;
    void Awake(){
        instance=this;
    }
    public static void UpdateFoodPanel(List<Food> foods){
        instance.Food1.sprite=foods[0].FoodSprite;
        instance.Food1.color=foods[0].FoodColor;
        if(foods.Count>1){
            instance.Food2.sprite=foods[1].FoodSprite;
            instance.Food2.color=foods[1].FoodColor;
        }
        if(foods.Count>2){
            instance.Food3.sprite=foods[2].FoodSprite;
            instance.Food3.color=foods[2].FoodColor;
        }
    }
}
