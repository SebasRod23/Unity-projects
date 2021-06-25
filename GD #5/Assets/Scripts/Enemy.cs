using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Awake()
    {
        GameManager.addEnemy(gameObject);
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity);
    }
    public void ActivateDeath()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Death");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") collision.gameObject.GetComponent<Player>().ActivateDeath();
    }
}
