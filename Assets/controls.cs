using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class controls : MonoBehaviour
{
    private float moveSpeed = 15f;
    private bool isGrounded;

    private float downWardsForce = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            downWardsForce = -downWardsForce;
            Debug.Log("executed");
            Physics.gravity = new Vector3(0, downWardsForce);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
       
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
