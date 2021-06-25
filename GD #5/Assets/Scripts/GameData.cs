using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float[,] enemiesPos;
    public float[,] staticPos;
    public float[,] movablePos;
    public float[,] boxPos;
    public float[,] t1Pos;
    public float[,] t2Pos;
    public float[] playerPos=new float[2];

    public GameData(List<GameObject> enemies, List<GameObject> statics, List<GameObject> movables, List<GameObject> targets1, List<GameObject> targets2, List<GameObject> boxes, GameObject player)
    {
        enemiesPos = new float[enemies.Count, 2];
        staticPos = new float[statics.Count, 2];
        movablePos = new float[movables.Count, 2];
        boxPos = new float[boxes.Count, 2];
        t1Pos = new float[targets1.Count, 2];
        t2Pos = new float[targets2.Count, 2];

        playerPos[0] = player.transform.position.x;
        playerPos[1] = player.transform.position.y;

        for (int i = 0; i < enemies.Count; i++)
        {
            enemiesPos[i, 0] = enemies[i].GetComponent<Transform>().position.x;
            enemiesPos[i, 1] = enemies[i].GetComponent<Transform>().position.y;
        }

        for (int i = 0; i < statics.Count; i++)
        {
            staticPos[i, 0] = statics[i].GetComponent<Transform>().position.x;
            staticPos[i, 1] = statics[i].GetComponent<Transform>().position.y;
        }

        for (int i = 0; i < movables.Count; i++)
        {
            movablePos[i, 0] = movables[i].GetComponent<Transform>().position.x;
            movablePos[i, 1] = movables[i].GetComponent<Transform>().position.y;
        }

        for (int i = 0; i < targets1.Count; i++)
        {
            t1Pos[i, 0] = targets1[i].GetComponent<Transform>().position.x;
            t1Pos[i, 1] = targets1[i].GetComponent<Transform>().position.y;
        }
        for (int i = 0; i < targets2.Count; i++)
        {
            t2Pos[i, 0] = targets2[i].GetComponent<Transform>().position.x;
            t2Pos[i, 1] = targets2[i].GetComponent<Transform>().position.y;
        }
        for (int i = 0; i < boxes.Count; i++)
        {
            boxPos[i, 0] = boxes[i].GetComponent<Transform>().position.x;
            boxPos[i, 1] = boxes[i].GetComponent<Transform>().position.y;
        }
    }
}
