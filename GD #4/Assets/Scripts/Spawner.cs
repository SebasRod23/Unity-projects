using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float seconds;
    public GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, seconds);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(tank, transform.position, Quaternion.identity);
    }
}
