using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpPower = 8f;
    public bool isGrounded = false;
    public Animator animator;
    public bool isJumpingTick;
    bool facingRight = true;
    public static Vector3 position;
    Fire Fire;
    public static bool isPlayerDead = false;
    public GameOverScreen gameOverScreen;
    bool playSoundOnce = false;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            if (!playSoundOnce)
            {
                backgroundMusic.Stop();
                SoundManagerScript.PlaySound("gameOver");
                playSoundOnce = true;
            }
            gameOverScreen.Setup();
            Time.timeScale = 0; // = 1 aby wznowic
        }

        position = transform.position;
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            animator.SetFloat("Horizontal", 1f);
        }
        else if (horizontal < 0)
        {
            animator.SetFloat("Horizontal", 1f);
        }
        else if (horizontal == 0)
        {
            animator.SetFloat("Horizontal", 0f);
        }
        //Debug.Log("horizontal = " + Input.GetAxis("Horizontal"));
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        /*if(Input.GetAxis("Horizontal") != 0 && !SoundManagerScript.audioSrc.isPlaying)
        {
            SoundManagerScript.PlaySound("runSound");
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            SoundManagerScript.audioSrc.Stop(); //pasowaloby dokladnie okreslic ktory dzwiek chcemy zatrzymac
        }*/

        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            flip();
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("IsJumping", true);
            isJumpingTick = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
            isJumpingTick = false;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D obwarzanek)
    {
        if (obwarzanek.gameObject.CompareTag("Obwarzanek"))
        {
            SoundManagerScript.PlaySound("obwarzanekEatSound");
            Destroy(obwarzanek.gameObject);
            Fire = FindObjectOfType<Fire>();
            if (Fire.FireStamina < 70f)
            {
                Fire.FireStamina += 30f;
            }
            else if (Fire.FireStamina >= 70f)
            {
                Fire.FireStamina = 100f;
            }

        }
    }
}