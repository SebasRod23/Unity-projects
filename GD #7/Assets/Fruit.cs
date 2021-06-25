using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int points;
    public bool collected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.gameObject.tag.Equals("Player") && !collected)
        {
            GetComponent<Animator>().SetTrigger("collected");
            GameManager.addPoints(points);
            collected = true;
            SoundManager.PlaySound("Collected");
        }
    }
    
}
