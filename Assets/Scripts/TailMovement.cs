using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour
{
    public float speed;
    public int index;
    public GameObject targetObject;
    public SnakeMove snakeMoveScript;

    private Vector3 tailTarget;
    private Transform targetTransform;
    private Transform tailTransform;

    void Start()
    {
        snakeMoveScript = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMove>();
        speed = snakeMoveScript.speed + 3f;

        targetObject = snakeMoveScript.tailObjects[snakeMoveScript.tailObjects.Count - 2];

        index = snakeMoveScript.tailObjects.IndexOf(gameObject);
        targetTransform = targetObject.transform;
        tailTransform = gameObject.transform;
    }
    void Update()
    {
        tailTarget = targetTransform.position;
        tailTransform.LookAt(tailTarget);
        tailTransform.position = Vector3.Lerp(tailTransform.position, tailTarget, Time.deltaTime * speed);
    }

}
