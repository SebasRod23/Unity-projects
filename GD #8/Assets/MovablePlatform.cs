using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public Transform target1, target2;
    public float speed;
    public float waitTime;
    public bool isWaiting;
    private Vector3 currentTarget;
    public int target;
    void Start()
    {
        currentTarget = target1.transform.position;
        target = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            if (waitTime <= 0)
            {
                isWaiting = false;
                waitTime = 5;
            }
            else waitTime = waitTime - Time.deltaTime;
        }
        else
        {
            Move();
            ChangeCurrentTarget();
        }
    }

    void Move()
    {
        if (target == 1)
        {
            float distance = Vector3.Distance(gameObject.transform.position, target1.transform.position);
            gameObject.transform.position = Vector3.Lerp(transform.position, target1.transform.position, (Time.deltaTime * speed) / distance);
        }
        else
        {
            float distance = Vector3.Distance(gameObject.transform.position, target2.transform.position);
            gameObject.transform.position = Vector3.Lerp(transform.position, target2.transform.position, (Time.deltaTime * speed) / distance);
        }

    }
    void ChangeCurrentTarget()
    {
        if (gameObject.transform.position == target1.transform.position)
        {
            target = 2;
            isWaiting = true;
        }
        else if (gameObject.transform.position == target2.transform.position)
        {
            target = 1;
            isWaiting = true;
        }
    }


    private Transform previousParent;
    private void OnCollisionEnter(Collision collision)
    {
        previousParent = gameObject.transform.parent;
        collision.gameObject.transform.parent = gameObject.transform;
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = previousParent;
        collision.gameObject.transform.parent = previousParent;
    }
}
