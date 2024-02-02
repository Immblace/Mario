using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int i;
    private PlayMove inventory;



    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayMove>();
    }


    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

    }


    public void droPP()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().addDrop();
            Destroy(child.gameObject);
        }
        
    }
}
