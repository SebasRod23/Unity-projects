using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
   
    private bool isDragging;
    public bool firstDrag;
    public float lastX, lastY;
    /*public DragController(bool fDrag)
    {
        this.firstDrag = fDrag;
    }*/
    // Update is called once per frame
    void Update()
    {
        if (firstDrag)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            gameObject.transform.Translate(mouseWorldPosition);
            if (Input.GetMouseButtonUp(0)) firstDrag = false;
            lastX = gameObject.transform.position.x;
            lastY = gameObject.transform.position.y;
        }
        if (isDragging)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            gameObject.transform.Translate(mouseWorldPosition);
            lastX = gameObject.transform.position.x;
            lastY = gameObject.transform.position.y;
        }

    }
    private void OnMouseDown()
    {
        //Debug.Log("Clicked");
        isDragging = true;
        
    }
    private void OnMouseUp()
    {
        //Debug.Log("Stopped click");
        isDragging = false;
    }
}
