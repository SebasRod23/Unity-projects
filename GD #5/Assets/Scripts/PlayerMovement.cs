using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool facingRight = true;
    private float speed = 2.5f;
    public int jumps = 2;
    private float jumpForce = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumps > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            jumps--;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Animator>().SetBool("isJumping", false);
            jumps = 2;
        }
        float x = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2( x* speed, GetComponent<Rigidbody2D>().velocity.y);
        
        if(GetComponent<Rigidbody2D>().velocity.y != 0) GetComponent<Animator>().SetBool("isJumping", true);
        else if (x != 0) GetComponent<Animator>().SetBool("isMoving", true);
        else if(x==0) GetComponent<Animator>().SetBool("isMoving", false);

        if (facingRight && x < 0) Flip();
        else if (!facingRight && x > 0) Flip();
    }
    private void Flip()
    {
        facingRight = !facingRight;
        if(!facingRight) transform.eulerAngles = new Vector3(0, -180, 0);
        else transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
