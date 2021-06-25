using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> staticPlatforms = new List<GameObject>();
    public static List<GameObject> movablePlatforms = new List<GameObject>();
    public static List<GameObject> misteryBoxes = new List<GameObject>();
    public static List<GameObject> targets1 = new List<GameObject>();
    public static List<GameObject> targets2 = new List<GameObject>();
    public static GameObject player = GameObject.FindGameObjectWithTag("Player");
    public static GameObject panelEdit = GameObject.FindGameObjectWithTag("Editor");
    public static GameObject gamePanel = GameObject.FindGameObjectWithTag("GamePanel");

    public static void addEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
        Debug.Log("Enemies: " + enemies.Count);
    }
    public static void addStaticPlatform(GameObject platform)
    {
        staticPlatforms.Add(platform);
    }
    public static void addMovablePlatform(GameObject platform)
    {
        movablePlatforms.Add(platform);
    }
    public static void addMisteryBox(GameObject box)
    {
        misteryBoxes.Add(box);
    }
    public static void addTarget1(GameObject target)
    {
        targets1.Add(target);
    }
    public static void addTarget2(GameObject target)
    {
        targets2.Add(target);
    }
    public static void deleteLastEnemy()
    {
        enemies.RemoveAt(enemies.Count - 1);
    }
    public static void ChangeModeToPlaying()
    {
        panelEdit.GetComponent<Animator>().SetBool("active", false);
        gamePanel.GetComponent<Animator>().SetBool("playing", true);

        player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        player.GetComponent<BoxCollider2D>().isTrigger = false;
        player.GetComponent<DragController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Rigidbody2D>().gravityScale = 1f;
            enemy.GetComponent<BoxCollider2D>().isTrigger = false;
            enemy.GetComponent<DragController>().enabled = false;
            //enemy.transform.parent = null;
            enemy.transform.SetParent(null);
            enemy.GetComponent<EnemyMovement>().enabled = true;
            enemy.GetComponentInChildren<Weapon>().enabled = true;
            enemy.GetComponentInChildren<BoxCollider2D>().enabled = true;
        }
        foreach (GameObject platform in staticPlatforms)
        {
            platform.GetComponent<DragController>().enabled = false;

        }
        foreach (GameObject platform in movablePlatforms)
        {
            platform.GetComponentInChildren<LinearMovement>().enabled = true;
            platform.GetComponentInChildren<AlignPlatform>().align = false;
        }
        foreach (GameObject target in targets1)
        {
            target.GetComponent<BoxCollider2D>().enabled = false;
            target.GetComponent<SpriteRenderer>().enabled = false;
        }
        foreach (GameObject target in targets2)
        {
            target.GetComponent<BoxCollider2D>().enabled = false;
            target.GetComponent<SpriteRenderer>().enabled = false;
        }
        foreach (GameObject box in misteryBoxes)
        {
            box.GetComponent<MisteryBox>().playing = true;
        }
    }
    public static void ChangeModeToEditing()
    {
        panelEdit.GetComponent<Animator>().SetBool("active", true);
        gamePanel.GetComponent<Animator>().SetBool("playing", false);

        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<BoxCollider2D>().isTrigger = true;
        player.GetComponent<DragController>().enabled = true;
        player.transform.position = new Vector3(player.GetComponent<DragController>().lastX, player.GetComponent<DragController>().lastY, 0);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        player.GetComponent<Animator>().SetBool("isMoving", false);
        player.GetComponent<Animator>().SetBool("isJumping", false);
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = false;

        foreach (GameObject enemy in enemies)
        {
            enemy.transform.SetParent(null);
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            enemy.GetComponent<BoxCollider2D>().isTrigger = true;
            enemy.GetComponent<DragController>().enabled = true;
            enemy.transform.position = new Vector3(enemy.GetComponent<DragController>().lastX, enemy.GetComponent<DragController>().lastY, 0);
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            enemy.GetComponent<EnemyMovement>().enabled = false;
            enemy.GetComponent<EnemyMovement>().facingRight = true;
            enemy.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            enemy.GetComponent<Animator>().SetBool("isMoving", false);
            enemy.GetComponent<SpriteRenderer>().enabled = true;
            enemy.GetComponentInChildren<Weapon>().enabled = false;
            enemy.GetComponentInChildren<BoxCollider2D>().enabled = false;
            enemy.GetComponent<BoxCollider2D>().enabled = true;
        }
        foreach (GameObject platform in staticPlatforms)
        {
            platform.GetComponent<DragController>().enabled = true;

        }
        foreach (GameObject platform in movablePlatforms)
        {
            platform.GetComponentInChildren<LinearMovement>().enabled = false;
            platform.GetComponentInChildren<AlignPlatform>().align = true;
        }
        foreach (GameObject target in targets1)
        {
            target.GetComponent<BoxCollider2D>().enabled = true;
            target.GetComponent<SpriteRenderer>().enabled = true;
        }
        foreach (GameObject target in targets2)
        {
            target.GetComponent<BoxCollider2D>().enabled = true;
            target.GetComponent<SpriteRenderer>().enabled = true;
        }
        foreach (GameObject box in misteryBoxes)
        {
            box.GetComponent<MisteryBox>().playing = false;
            box.GetComponent<MisteryBox>().opened = false;
        }
    }
    public static void deleteFromList(List<GameObject> list, int leftover)
    {
        for (int i = 0; i < leftover; i++)
        {
            GameObject g = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            GameObject.Destroy(g);
        }
    }
    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/objects.pstn";
        FileStream stream = new FileStream(path, FileMode.Create);
        //Debug.Log("SAVING... Enemies: " + enemies.Count + ", Statics: " + staticPlatforms.Count + ", Movable: " + movablePlatforms.Count + ", T1: " + targets1.Count + ", T2: " + targets2.Count + " Boxes: " + misteryBoxes.Count);
        GameData gd = new GameData(enemies, staticPlatforms, movablePlatforms, targets1, targets2, misteryBoxes, player);
        formatter.Serialize(stream, gd);
        stream.Close();
    }
    public static GameData ReadFile()
    {
        string path = Application.persistentDataPath + "/objects.pstn";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gd = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gd;
        }
        else
        {
            Debug.Log("There is no file in path: " + path);
            return null;
        }
    }
    public static void LoadGame()
    {
        GameData data = ReadFile();

        //Debug.Log("------Loading-------");
        //Debug.Log("LOADING... Enemies: " + data.enemiesPos.Length/2 + ", Statics: " + data.staticPos.Length/2 + ", Movable: " + data.movablePos.Length/2 + ", T1: " + data.t1Pos.Length/2 + ", T2: " + data.t2Pos.Length/2 + " Boxes: " + data.boxPos.Length/2);
        player.transform.position = new Vector3(data.playerPos[0], data.playerPos[1], 0);
        player.GetComponent<DragController>().lastX = data.playerPos[0];
        player.GetComponent<DragController>().lastY = data.playerPos[1];


        deleteFromList(enemies, enemies.Count );
        deleteFromList(staticPlatforms, staticPlatforms.Count );
        deleteFromList(movablePlatforms, movablePlatforms.Count );
        targets1.Clear();
        targets2.Clear();
        deleteFromList(misteryBoxes, misteryBoxes.Count );
        for (int j = 0; j < data.enemiesPos.Length / 2; j++)
        {
            GameObject g = GameObject.Instantiate(Resources.Load("Enemy"), new Vector3(data.enemiesPos[j, 0], data.enemiesPos[j, 1], 0), Quaternion.identity) as GameObject;
            g.GetComponent<DragController>().firstDrag = false;
            g.GetComponent<DragController>().lastX = data.enemiesPos[j, 0];
            g.GetComponent<DragController>().lastY = data.enemiesPos[j, 1];

        }
        for (int j = 0; j < data.staticPos.Length / 2; j++)
        {

            GameObject g = GameObject.Instantiate(Resources.Load("Static Platform", typeof(GameObject)) as GameObject, new Vector3(data.staticPos[j, 0], data.staticPos[j, 1], 0), Quaternion.identity) as GameObject;
            g.GetComponent<DragController>().firstDrag = false;
        }
        for (int j = 0; j < data.movablePos.Length / 2; j++)
        {
            GameObject g = GameObject.Instantiate(Resources.Load("Movable Platform", typeof(GameObject)) as GameObject, new Vector3(data.movablePos[j, 0], data.movablePos[j, 1], 0), Quaternion.identity) as GameObject;
            g.GetComponent<DragController>().firstDrag = false;
        }
        int i = 0;
        foreach (GameObject target in targets1)
        {
            target.transform.position = new Vector3(data.t1Pos[i, 0], data.t1Pos[i, 1], 0);
            i++;
        }
        i = 0;
        foreach (GameObject target in targets2)
        {
            target.transform.position = new Vector3(data.t2Pos[i, 0], data.t2Pos[i, 1], 0);
            i++;
        }

        for (int j = 0; j < data.boxPos.Length / 2; j++)
        {
            GameObject g = GameObject.Instantiate(Resources.Load("Mistery-Box", typeof(GameObject)) as GameObject, new Vector3(data.boxPos[j, 0], data.boxPos[j, 1], 0), Quaternion.identity) as GameObject;
            g.GetComponent<DragController>().firstDrag = false;
        }

    }
}
