using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("finished");
        SoundManager.PlaySound("Reached");
    }
}
