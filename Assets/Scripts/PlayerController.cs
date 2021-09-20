using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public bool lvl01Complete;
    public bool lvl02Complete;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    public GameObject playfieldOne;
    public GameObject playfieldTwo;
    public Transform lvl2spawn;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    public int count;
    public int lives;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        // Set the count to zero 
        count = 0;
        lives = 3;

        lvl01Complete = false;
        lvl02Complete = false;
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        //playfieldOne.SetActive(true);
        //playfieldTwo.SetActive(false);
        SetCountText();
    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        lvlCTRL();
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            // Add one to the score variable 'count'
            count = count + 1;
            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            other.gameObject.SetActive(false);
            // Add one to the score variable 'count'
            count = count - 1;
            lives = lives - 1;
            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    public void lvlCTRL()
    {
        if (count >= 8 && !lvl01Complete && !lvl02Complete)
        {
            // Set the text value of your 'winText'
            // winTextObject.SetActive(true);
            lvl01Complete = true;
            count = 0;
            lives = 3;
            transform.position = lvl2spawn.transform.position;
            SetCountText();
            //playfieldOne.SetActive(false);
            //playfieldOne.SetActive(true);
        }
        if (count >= 8 && lvl01Complete && !lvl02Complete)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
            lvl02Complete = true;

        }
        if (lives <= 0)
        {
            loseTextObject.SetActive(true);
            Time.timeScale = 0.01f;
        }

    }
}