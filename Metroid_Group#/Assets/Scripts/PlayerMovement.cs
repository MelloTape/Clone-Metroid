using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Arteaga, Yasmine and Benavides, Selena
/// 10/26/23
/// Handles the player's movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public int lives = 3;

    public int health = 99;

    public int totalCoins = 0;

    public float speed = 10f;

    private Rigidbody rigidBody;
    public int jumpForce = 10;
    public bool isGrounded;

    public float deathYlevel = -3f;

    private Vector3 startPos;
    private bool stunned = false;

    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        //set the starting position
        startPos = transform.position;
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

    private void Respawn()
    {
        if (!isInvincible)
        {
            //Teleports player to start position and causes player to lose a life
            lives--;
            transform.position = startPos;

            StartCoroutine(SetInvincible());

            if (lives == 0)
            {
                SceneManager.LoadScene(1);
                Debug.Log("Game Ends");
            }
        }
        else
        {
            Debug.Log("Player is invincible and so doesn't take damage");
        }
        
    }

    private void CheckForDamage()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1))
        {
            if (hit.collider.tag == "Thwamp")
            {
                Respawn();
            }
        }
    }

    /// <summary>
    /// Collects any coins
    /// </summary>
    /// <param name="other">the object being collided with</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            totalCoins++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Respawn();
        }

        

        if (other.gameObject.tag == "Laser")
        {
            StartCoroutine(StunPlayer());
        }
    }

    //sets stunned to true for x amount of seconds, then sets it back to false.
    IEnumerator StunPlayer()
    {
        stunned = true;
        yield return new WaitForSeconds(2f);
        stunned = false;
    }

    IEnumerator SetInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(5f);
        isInvincible = false;
    }
}
