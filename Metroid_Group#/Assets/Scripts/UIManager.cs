using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text healthText;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        //This creates the health UI
    }

    // Update is called once per frame
    void Update()
    {
        //This adds the health to the top left
        healthText.text = "Health: " + playerMovement.health.ToString();
    }
}
