using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Arteaga, Yasmine and Benavides, Selena
/// 10/26/23
/// Handles the player's rotation
/// </summary>

public class Rotate : MonoBehaviour
{
    private bool facingRight = true;

    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        turn();
    }

    private void turn()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        ///if (Input.GetKeyDown(KeyCode.D))
        //{
            //transform.Rotate(Vector3.up * 180);
        //}
    }
}
