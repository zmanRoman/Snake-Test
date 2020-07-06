using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject food;
    public GameObject ground;
    public float yUpperPosition = 0f;

    private float lineX;
    private float lineY;
    private Vector3 foodPosition;

    private static FoodSpawn instance;
    public static FoodSpawn Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       lineX = ground.transform.localScale.x; // длина ground по X
       lineY = ground.transform.localScale.y; // длина ground по Y

       PositionFoodUpperGround();
    }


    public void PositionFoodUpperGround()
    {
        foodPosition = new Vector3(  // создаем Food, располагая в зависимости от длины Х и У Ground
            x: Random.Range(-lineX / 2, lineX / 2),
            y: yUpperPosition,
            z: Random.Range(-lineY / 2, lineY / 2));

        food.transform.position = foodPosition;   
    }

    
}
