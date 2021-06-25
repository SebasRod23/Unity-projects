using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool facingRight = true;
    private float speed = 3.5f;
    public int jumps = 2;
    private float jumpForce = 5.5f;
    public Transform checkpoint;
    public int lives = 3;

    private void Start()
    {
        setCheckPoint(gameObject.transform);
    }
    private void Update()
    {
        if (lives == 0) Respawn();
        if (Input.GetKeyDown(KeyCode.W) && jumps > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            if (jumps == 2) GetComponent<Animator>().SetTrigger("jump");
            else if (jumps == 1) GetComponent<Animator>().SetTrigger("doubleJump");
            jumps--;
        }
    }
    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Animator>().SetBool("isFalling", false);
            jumps = 2;
        }
        float x = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(x * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (GetComponent<Rigidbody2D>().velocity.y < 0) GetComponent<Animator>().SetBool("isFalling", true);
        else if (x != 0) GetComponent<Animator>().SetBool("isMoving", true);
        else if (x == 0) GetComponent<Animator>().SetBool("isMoving", false);

        if (facingRight && x < 0) Flip();
        else if (!facingRight && x > 0) Flip();
    }
    private void Flip()
    {
        facingRight = !facingRight;
        if (!facingRight) transform.eulerAngles = new Vector3(0, -180, 0);
        else transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void setCheckPoint(Transform c)
    {
        checkpoint = c;
    }
    public void Respawn()
    {
        GameManager.reduceTime(10);
        gameObject.transform.position = new Vector3(checkpoint.position.x, checkpoint.position.y, 0);
        lives = 3;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        
    }
}
