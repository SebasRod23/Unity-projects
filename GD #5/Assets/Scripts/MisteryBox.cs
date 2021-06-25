using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects=new GameObject[3];
    public bool opened=false;
    public bool playing = false;
    private void Awake()
    {
        GameManager.addMisteryBox(gameObject);
    }
    private void Update()
    {
        if (opened) gameObject.GetComponent<SpriteRenderer>().enabled = false;
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter");
        if (collision.gameObject.tag.Equals("Player")&&!opened&&playing)
        {
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                GameObject enemy = Instantiate(objects[random], gameObject.transform.position, Quaternion.identity);
                enemy.GetComponent<Transform>().parent = gameObject.transform;
                enemy.GetComponent<Rigidbody2D>().gravityScale = 1;
                enemy.GetComponent<BoxCollider2D>().isTrigger = false;
                enemy.GetComponent<DragController>().enabled = false;
                enemy.GetComponent<DragController>().firstDrag = false;
                enemy.GetComponent<EnemyMovement>().enabled = true;
                GameManager.deleteLastEnemy();

            }
            else
            {
                GameObject potion = Instantiate(objects[random], gameObject.transform.position, Quaternion.identity);
                potion.GetComponent<Transform>().parent = gameObject.transform;
            }
            opened = true;
            //Debug.Log("Selected randmoly: " + random);
        }
    }
}
