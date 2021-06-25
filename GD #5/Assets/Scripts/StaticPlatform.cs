using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatform : MonoBehaviour
{
    private void Awake()
    {
        GameManager.addStaticPlatform(gameObject);
    }
}
