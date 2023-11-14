using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //game objects to determine how far left/right enemy goes - 2
    public GameObject leftPoint;
    public GameObject rightPoint;

    //boundary points for left/right -  2
    private Vector3 leftPos;
    private Vector3 rightPos;

    //how fast the enemy travels - 1 
    public float speed;

    //the direction it is going - 1
    public bool goingLeft;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (goingLeft == true)
        {
            //once the enemy reaches the left point - going is false 
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                //transform the enemy left by speed using Time.deltaTime
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            //once the enemy reaches the rightPos - goingLeft is true
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                //translate the enemy right by speed using Time.deltaTime
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
