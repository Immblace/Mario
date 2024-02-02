using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Coins : MonoBehaviour
{
    public int count;
    private AudioSource source;
    public AudioClip coinUp;

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            source.PlayOneShot(coinUp);
            collision.GetComponent<Player>().AddCoin(count);
            Destroy(gameObject);
            
        }
    }
}
