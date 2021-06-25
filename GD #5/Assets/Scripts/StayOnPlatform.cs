using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    private Transform previousParent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        previousParent = gameObject.transform.parent;
        collision.gameObject.transform.parent = gameObject.transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = previousParent;
        collision.gameObject.transform.parent = previousParent;
    }
}
