using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class controls : MonoBehaviour
{
    private float moveSpeed;
    private bool isGrounded;
    Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 0.5f;

    private float downWardsForce = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }*/

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.VelocityChange);
            downWardsForce = -downWardsForce;
            Physics.gravity = new Vector3(0, downWardsForce);
            //isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
