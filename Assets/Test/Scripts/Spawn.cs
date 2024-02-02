using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Transform PlayerPos;
    public GameObject MaxiMe;


    private void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void addDrop()
    {
        Vector2 PlayerPoss = new Vector2(PlayerPos.position.x + 2 , PlayerPos.position.y);
        Instantiate(MaxiMe , PlayerPoss , Quaternion.identity); 
    }





}
