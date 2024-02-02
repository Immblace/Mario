using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float boostSpeed;
    private float startSpeed;
    private float timer;

    private bool isGrounded;

    private Rigidbody2D _rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource jumpAudio;
    private Weapon Weapon;

    public int score;
    public TextMeshProUGUI mytext;

    private float moveSpeed;
    private float normalSpeed = 4f;
    private float readyJump;
    private float readyFire;
    private Vector2 touchMove;


    private void Start()
    {
        moveSpeed = 0f;
        startSpeed = speed;
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        mytext.text = score.ToString();
        jumpAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        mouseMove();
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if (readyJump > 0)
        {
            readyJump -= 0.1f;
        }

        if (readyFire > 0)
        {
            readyFire -= Time.deltaTime;

            if (readyFire <= 0)
            {
                Shoot();
            }
        }


        if (Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }

        
        if (Weapon != null)
        {
            if (spriteRenderer.flipX)
            {
                Weapon.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y);
                Weapon.transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
                Weapon.bulletRight = false;
            }
            else
            {
                Weapon.transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
                Weapon.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                Weapon.bulletRight = true;
            }
        }


        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        Vector3 position = transform.position;
        position.x += Input.GetAxis("Horizontal") * speed;
        transform.position = position;

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
            animator.SetInteger("State", 1);
        }
        else
        {
            //animator.SetInteger("State", 0);
        }


        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            speed = startSpeed;
        }
    }

    public void Jump()
    {
        jumpAudio.Play();
        _rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void AddCoin(int count)
    {
        score += count;
        mytext.text = score.ToString();
    }

    public void BoostSpeed()
    {
        speed = boostSpeed;
        timer = 4f;
    }

    public void BonusHeight()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        timer = 4f;
    }

    public void Shoot()
    {
        if (Weapon != null)
        {
            Weapon.Fire();
        }
    }

    public void BuyWeapon(Weapon Weapon)
    {
        this.Weapon = Weapon;
        mytext.text = score.ToString();
    }


    public void MoveRight()
    {

        spriteRenderer.flipX = false;
        moveSpeed = normalSpeed;
        animator.SetInteger("State", 1);


    }

    public void MoveLeft()
    {

        spriteRenderer.flipX = true;
        moveSpeed = -normalSpeed;
        animator.SetInteger("State", 1);

    }

    public void ButtonUp()
    {
        moveSpeed = 0f;
        readyFire = 0;
        animator.SetInteger("State", 0);
    }

    public void ButtonJump()
    {
        readyJump += 1;

        if (readyJump > 1 && isGrounded)
        {
            jumpAudio.Play();
            _rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            readyJump = 0;
        }
    }

    public void ButtonFire()
    {
        readyFire = 0.8f;
    }

    private void mouseMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchMove = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)Input.mousePosition - touchMove;

            if (delta.magnitude > 150)
            {
                if (delta.x > 0)
                {
                    moveSpeed = 4;
                    animator.SetInteger("State", 1);
                    spriteRenderer.flipX = false;
                }
                else
                {
                    moveSpeed = -4;
                    animator.SetInteger("State", 1);
                    spriteRenderer.flipX = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveSpeed = 0;
            touchMove = Vector2.zero;
            animator.SetInteger("State", 0);
        }
    }


}
