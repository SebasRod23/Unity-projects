using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocity;
    private float initialPosition;
    private void Start()
    {
        initialPosition = gameObject.transform.position.x;
    }
    void Update()
    {
        rigidbody.velocity = new Vector3(velocity, 0, 0);
        if (Mathf.Abs(initialPosition - gameObject.transform.position.x) > 30) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
