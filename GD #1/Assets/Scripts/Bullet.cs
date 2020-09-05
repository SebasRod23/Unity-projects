using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody2D rigidbody;
    public GameObject bulletHit;
    private double originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity=transform.right*speed;
        originalPosition=transform.position.x;
    }
    void Update(){
        if(originalPosition+40<=transform.position.x) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D target){
        if(!target.gameObject.tag.Equals("Weapon")&&!target.gameObject.tag.Equals("Ammo")&&!target.gameObject.tag.Equals("Coin")){
            Instantiate(bulletHit, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
    }

}
