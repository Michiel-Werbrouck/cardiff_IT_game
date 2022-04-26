using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float movementSpeed = 10f;

    public float gravityForce = 2;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
}
