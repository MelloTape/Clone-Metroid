using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arteaga, Yasmine and Benavides, Selena
/// 10/26/23
/// Handles the player's movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rigidBody;
    public int jumpForce = 10;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            Debug.Log("Inputed the a key");
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            Debug.Log("Inputed the d key");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        spaceJump();
    }

    public void spaceJump()
    {
        //Raycast detecting if player isGrounded or not
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
            Debug.Log("Player is grounded");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Player is not grounded");
        }

        //Player is able to jump with the "space" key and if isGrounded is true
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
