using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloewPlayer : MonoBehaviour
{
    public Transform player;
    public float offsetX, offsetY;
  
    void Update()
    {
        gameObject.transform.position = new Vector3(player.position.x + offsetX, player.position.y + offsetY, -10);
    }
}
