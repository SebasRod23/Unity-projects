using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool isBeneficial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (isBeneficial)
            {
                //collision.gameObject.GetComponent<PlayerHealth>        
                
                StartCoroutine(ColorEffect(collision.gameObject, Color.green));
            }
            else
            {
                StartCoroutine(ColorEffect(collision.gameObject, Color.red));
            }
        }
    }
    
    IEnumerator ColorEffect(GameObject player, Color color)
    {
        player.gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        
        //Debug.Log("Changing to "+color);
        yield return new WaitForSeconds(1f);
        player.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //Debug.Log("Changing to white");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
