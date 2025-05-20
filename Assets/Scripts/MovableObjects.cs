using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjects : MonoBehaviour
{
    public float distance = 15f; // Distance that moves the object
    public bool horizontal = true; // If the movement is horizontal or vertical
    public float speed = 20f;
    public float offset = 0f; // If you want to modify the position at the start

    private bool isForward = false; // If the movement is out
    private Vector3 startPos;
    public float waitTimeGo = 2f;
    public float samewaitTimeGo = 2f;
    public float waitTimeBack = 4f;
    public float samewaitTimeBack = 4f;
    private bool isWaitingGo = false;
    private bool isWaitingBack = false;

    void Awake()
    {
        startPos = transform.position;
        if (horizontal)
            transform.position += Vector3.right * offset;
        else
            transform.position += Vector3.forward * offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaitingGo)
        {
            waitTimeGo -= Time.deltaTime;
            if (waitTimeGo <= 0f)
            {
                isWaitingGo = false;
                waitTimeGo = samewaitTimeGo;
            }
            else
            {
                return;
            }
        }

        if (isWaitingBack)
        {
            waitTimeBack -= Time.deltaTime;
            if (waitTimeBack <= 0f)
            {
                isWaitingBack = false;
                waitTimeBack = samewaitTimeBack;
            }
            else
            {
                return;
            }
        }

        if (horizontal)
        {
            if (isForward)
            {
                if (transform.position.x > startPos.x - distance)
                {
                    transform.position -= Vector3.right * Time.deltaTime * speed;
                }
                else
                {
                    isForward = false;
                    isWaitingGo = true;
                }
            }
            else
            {
                if (transform.position.x < startPos.x)
                {
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
                else
                {
                    isForward = true;
                    isWaitingBack = true;
                }
            }
        }
        else
        {
            if (isForward)
            {
                if (transform.position.z > startPos.z - distance)
                {
                    transform.position -= Vector3.forward * Time.deltaTime * speed;
                }
                else
                {
                    isForward = false;
                    isWaitingGo = true;
                }
            }
            else
            {
                if (transform.position.z < startPos.z)
                {
                    transform.position += Vector3.forward * Time.deltaTime * speed;
                }
                else
                {
                    isForward = true;
                    isWaitingGo = true;
                }
            }
        }
    }
}
