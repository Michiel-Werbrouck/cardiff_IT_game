using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{   
    public float movementSpeed = 10f;
    public float gravityForce = 2;

    private Rigidbody2D rb;
    private GManager gameManager;
    private Animator anim;
    private SpriteRenderer sRenderer;

    void Start()
    {
        gameManager = FindObjectOfType<GManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (gameManager.State == GameState.InProgress)
        {
            anim.SetBool("isRunning", true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.gravityScale = -gravityForce;
                sRenderer.flipY = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.gravityScale = gravityForce;
                sRenderer.flipY = false;
            }
        } 
            
        if (gameManager.State == GameState.Finished)
        {
            anim.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        if (gameManager.State == GameState.InProgress)
        {
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.right);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            gameManager.Lose();
        }

        if (collision.gameObject.tag == "Point")
        {
            Destroy(collision.gameObject);
            gameManager.IncreaseScore();
        }
    }
}
