using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arteaga, Yasmine and Benavides, Selena
/// 10/31/23
/// Handles the camera following the player
/// </summary>

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //transform position of the camera - transform position of the target
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //as the target/player moves we add offset to this object
        transform.position = target.transform.position + offset;
    }
}
