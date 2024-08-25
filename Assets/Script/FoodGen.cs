using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGen : MonoBehaviour
{
    public GreadSystem greadSystem;
    public GameObject foodBase;
    public Food food1;
    private int timer;
    public int CooldownTicks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timer++;
        if (timer >= CooldownTicks)
        {
            timer = 0;
            GenOneFood();
        }
    }
    private void GenOneFood()
    {
        List<Vector2Int> candidates = new();
        for (int x = 0; x < greadSystem.GetWidth(); x++)
        {
            for (int y = 0; y < greadSystem.GetHeight(); y++)
            {
                Gread gread = greadSystem.greads[x, y];
                if (gread.isEmpty())
                {
                    candidates.Add(new Vector2Int(x, y));
                }
            }
        }
        if (candidates.Count > 0)
        {
            int rnd = Random.Range(0, candidates.Count);
            Vector2Int pos = candidates[rnd];
            Gread gread = greadSystem.greads[pos.x, pos.y];
            GameObject foodObject = Instantiate(foodBase);
            FoodObject foodObjectObject=foodObject.GetComponent<FoodObject>();
            foodObjectObject.FoodType=food1;
            foodObjectObject.FoodImage.sprite=food1.FoodSprite;
            foodObjectObject.FoodImage.color=food1.FoodColor;
            foodObjectObject.mygread=gread;
            foodObject.transform.position = new Vector3(gread.x, gread.y, 0);
            gread.collectable = foodObject.GetComponent<ICollectable>();
        }
    }
}
