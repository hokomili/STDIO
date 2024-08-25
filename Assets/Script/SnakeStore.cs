using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeStore : MonoBehaviour
{
    public static SnakeStore MainStore;
    public List<Food> Foods=new();
    public static void Feed(Food food){
        if(MainStore.Foods.Count<3){
            MainStore.Foods.Add(food);
        }
        else{
            MainStore.Foods.RemoveAt(0);
            MainStore.Foods.Add(food);
        }
        FoodPanel.UpdateFoodPanel(MainStore.Foods);
    }
    void Awake()
    {
        if(MainStore == null)MainStore=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
