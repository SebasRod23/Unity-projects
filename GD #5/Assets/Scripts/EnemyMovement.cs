using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform checker;
    private float speed = 1f;
    public bool facingRight = true;
    public Transform playerChecker;
    

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D raycast = Physics2D.Raycast(checker.position, Vector2.down, 1f);
            if (!raycast.collider)
            {
                if (facingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    facingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facingRight = true;
                }
            }
            RaycastHit2D raycast2 = Physics2D.Raycast(playerChecker.position, Vector2.right, 1f);
            if (raycast2.collider)
            {
                if (raycast2.collider.tag == "Player")
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    gameObject.GetComponent<Animator>().SetTrigger("Attack");
                    
                }
            }
        }
        
    }
}
