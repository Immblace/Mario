using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopButton;
    [SerializeField] private GameObject ShopMenu;
    [SerializeField] private Weapon Ak47;
    private Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ShopButton.SetActive(false);
        ShopMenu.SetActive(false);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShopButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ShopButton.SetActive(false);
            ShopMenu.SetActive(false);
        }
    }

    public void ShowMenu()
    {
        ShopMenu.SetActive(true);
    }


    public void BuyAk47()
    {
        if (player.score >= Ak47.price)
        {
            player.score -= Ak47.price;
            Weapon newWeapon = Instantiate(Ak47);
            player.BuyWeapon(newWeapon);
        }
    }

}
