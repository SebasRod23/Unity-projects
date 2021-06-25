using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public float speed;
    private Vector3 currentTarget;
    private int target;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = target1.transform.position;
        target = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeCurrentTarget();
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
        if (gameObject.transform.position == target1.transform.position) target = 2;//currentTarget = target2.transform.position;
        else if (gameObject.transform.position == target2.transform.position) target = 1;//currentTarget = target1.transform.position;
    }
}
