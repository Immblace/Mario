using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet Bullet;
    [SerializeField] private Transform BulletSpawn;
    public int price;
    public bool bulletRight;

    public bool changeweapon;



    private void Update()
    {
        if (changeweapon && Input.GetKeyDown(KeyCode.K))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().BuyWeapon(this);
            changeweapon = false;
        }
    }

    public void Fire()
    {
        Bullet NewBullet = Instantiate(Bullet , BulletSpawn.position, BulletSpawn.rotation);
        if (bulletRight)
        {
            NewBullet.bulletmove = Vector3.right;
        }
        else
        {
            NewBullet.bulletmove = Vector3.left;
        }
    }


    public void GiveWeapon(Weapon weapon)
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().score >= weapon.price)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().score -= weapon.price;
            Weapon weap = Instantiate(weapon);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().BuyWeapon(weap);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            changeweapon = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            changeweapon = false;
        }
    }

}
