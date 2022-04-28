using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{   
    public float movementSpeed = 10f;
    public float gravityForce = 2;

    private Rigidbody2D rb;
    private GManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameManager.State == GameState.InProgress)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.gravityScale = -gravityForce;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.gravityScale = gravityForce;
            }
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
