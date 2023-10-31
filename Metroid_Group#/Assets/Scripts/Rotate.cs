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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(Vector3.up * 90);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.forward is the forward direction of an object based on where it's facing
            transform.position += transform.forward * Time.deltaTime * 5f;
        }
    }
}
