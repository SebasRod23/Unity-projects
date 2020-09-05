using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform groundDetector;
    private bool facingRight;
    public GameObject Enemy_death;
    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
        RaycastHit2D groundInfo=Physics2D.Raycast(groundDetector.position, Vector2.down,2f);
        if(!groundInfo.collider){
            Flip();
        }
        //transform.eulerAngles=new Vector3()
    }
    private void Flip()
    {
        //Debug.Log("Enter");
        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);
        //Debug.Log(facingRight);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Bullet"))
        {
            Instantiate(Enemy_death, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
