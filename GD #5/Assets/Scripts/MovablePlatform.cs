using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    private void Awake()
    {
        GameManager.addMovablePlatform(gameObject);
        GameManager.addTarget1(gameObject.GetComponentInChildren<LinearMovement>().target1.gameObject);
        GameManager.addTarget2(gameObject.GetComponentInChildren<LinearMovement>().target2.gameObject);
    }
    void Update()
    {
        if (!gameObject.GetComponent<DragController>().firstDrag)
        {
            gameObject.GetComponent<DragController>().enabled = false;
            gameObject.GetComponentInChildren<LinearMovement>().target1.gameObject.GetComponent<DragController>().enabled = true;
            gameObject.GetComponentInChildren<LinearMovement>().target2.gameObject.GetComponent<DragController>().enabled = true;
        }
    }
}
