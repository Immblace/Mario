using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 5f;
    private bool isGrounded;

    public GameObject[] Inventory;
    public bool[] isFull;
    public GameObject invent;
    private bool invetnOp;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        invetnOp = true;
    }

    private void Update()
    {
        MovePlayer();


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
    }

    public void InventChange()
    {
        if (invetnOp)
        {
            invetnOp = false;
            invent.SetActive(false);
        }
        else if (!invetnOp)
        {
            invetnOp = true;
            invent.SetActive(true);
        }
    }



    private void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + h , transform.position.y);
    }

    private void jump()
    {
        _rb.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
