using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject txt;
    public int ammo;
    public bool isDead;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&ammo>0&&!isDead) {
            shoots();
            ammo--;
            txt.GetComponent<UnityEngine.UI.Text>().text ="Ammo:        x"+ ammo.ToString();
        }
        reloadCounter();
    }
    private void shoots(){
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    public void addBullets(int bullets){
        ammo+=bullets;
        txt.GetComponent<UnityEngine.UI.Text>().text = "Ammo:        x" + ammo.ToString();
    }
    public void reloadCounter(){
        txt.GetComponent<UnityEngine.UI.Text>().text = "Ammo:        x" + ammo.ToString();
    }
}
