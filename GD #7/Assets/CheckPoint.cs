using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform checkpoint;
    public Player player;
    public bool reached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.setCheckPoint(checkpoint);
        if (collision.gameObject.tag.Equals("Player") && !reached){
            GetComponent<Animator>().SetTrigger("reached");
            
            reached = true;
            GameManager.reduceTime(-15);
            SoundManager.PlaySound("Reached");
        }
    }

}
