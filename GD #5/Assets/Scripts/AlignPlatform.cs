using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignPlatform : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public bool align;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(align) CalculateDistance();
    }

    private void CalculateDistance()
    {
        Vector3 vector = Vector3.Lerp(target1.transform.position, target2.transform.position, .5f);
        //vector.x = vector.x - 2.03f / 2;
        //vector.y = vector.y - 0.86f / 2;
        gameObject.transform.position = vector;
        //Debug.Log("Vector: "+vector);
    }
}
