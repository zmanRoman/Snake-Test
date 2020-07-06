using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float yUnderPosition = -4;

    private Vector3 positionUnderGround;
    private Transform transformComponent;

    private void Start()
    {
        transformComponent = gameObject.transform;

        positionUnderGround = new Vector3( //получаем позицию для размещения под Ground
            x: transformComponent.position.x,
            y: yUnderPosition,
            z: transformComponent.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
      //  if (other.CompareTag("SnakeHead"))
       // {
            other.GetComponent<SnakeMove>().AddTail();
            transformComponent.position = positionUnderGround;

            FoodSpawn.Instance.PositionFoodUpperGround();
      //  }
    }
}
