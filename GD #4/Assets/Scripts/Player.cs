using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //public Rigidbody2D rigidbody;
    //private float lastX;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D)&&!CheckObstacleRight()) {
            //float x = transform.position.x + 1;
            //rigidbody.transform.position = new Vector3(x, transform.position.y, transform.position.z);
            transform.Translate(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A)&&!CheckObstacleLeft())
        {
            //float x = transform.position.x - 1;
            //rigidbody.transform.position = new Vector3(x, transform.position.y, transform.position.z);
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W)&&!CheckObstacleFoward())
        {
            //float y = transform.position.y + 1;
            //rigidbody.transform.position = new Vector3(transform.position.x, y, transform.position.z);
            transform.Translate(0, 1, 0);
            //lastY = transform.position.y;
        }
        if (Input.GetKeyDown(KeyCode.S)&&!CheckObstacleBehind())
        {
            //float y = transform.position.y - 1;
            //rigidbody.transform.position = new Vector3(transform.position.x, y, transform.position.z);
            transform.Translate(0, -1, 0);
            //lastY = transform.position.y;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            transform.position = new Vector3(0, -4, transform.position.z);
        }

    }
    
    private bool CheckObstacleFoward()
    {
        //Debug.DrawRay(transform.position, Vector3.up * .5f, Color.red);
        RaycastHit2D raycast= Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y+0.5f), Vector2.up, .5f);
        if (raycast.collider != null) return raycast.collider.gameObject.tag.Equals("Obstacle");
        else return false;
        
    }
    private bool CheckObstacleBehind()
    {
        RaycastHit2D raycast = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), -Vector2.up, .5f);
        if (raycast.collider != null) return raycast.collider.gameObject.tag.Equals("Obstacle");
        else return false;
    }
    private bool CheckObstacleLeft()
    {
        //Debug.DrawRay(new Vector3(transform.position.x-0.5f, transform.position.y,0), Vector3.left * .5f, Color.red);
        RaycastHit2D raycast = Physics2D.Raycast(new Vector2(transform.position.x - 0.6f, transform.position.y), Vector2.left, .5f);
        if (raycast.collider != null) return raycast.collider.gameObject.tag.Equals("Obstacle");
        else return false;
    }
    private bool CheckObstacleRight()
    {
        RaycastHit2D raycast = Physics2D.Raycast(new Vector2(transform.position.x + 0.6f, transform.position.y), Vector2.right, .5f);
        if (raycast.collider != null) return raycast.collider.gameObject.tag.Equals("Obstacle");
        else return false;
    }

}
