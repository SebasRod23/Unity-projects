using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public GameObject prefab;
    //public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Clicked()
    {
        //OnMouseDown();
        //Debug.Log("Enemy clicked");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Instantiate(prefab, mousePosition, Quaternion.identity);
        //panel.gameObject.SetActive(false);
    } 


}
