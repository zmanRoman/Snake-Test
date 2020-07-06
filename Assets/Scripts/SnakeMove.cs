using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeMove : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public List<GameObject> tailObjects = new List<GameObject>();
    public float z_offset = 0.5f;

    public GameObject tailPrefab;

    private Transform transformComponent;

    private bool isLeft = false;
    private bool isRight = false;

    private void Start()
    {
        tailObjects.Add(gameObject);
        transformComponent = transform;
    }
    private void Update()
    {
        transformComponent.Translate(Vector3.forward * speed * Time.deltaTime);

        if(isLeft)
        {
            LeftButton();
        }

        if(isRight)
        {
            RightButton();
        }
    }

    public void AddTail()
    {
        ScoreController.Instance.Score++;

        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;
        tailObjects.Add(Instantiate(tailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }

    public void ControllLeftTrigger(bool _left)
    {
        isLeft = _left;
    }

    public void ControllRightTrigger(bool _right)
    {
        isRight = _right;
    }

    private void LeftButton()
    {
        isLeft = true;
        transformComponent.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void RightButton()
    {
        transformComponent.Rotate(Vector3.up * -1 * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Tail"))
        {
            speed = 0;
            ButtonOnClick.Instance.ActiveGameObject(ButtonOnClick.Instance.reloadPopup);
        }

    }
}
