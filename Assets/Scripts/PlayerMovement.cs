using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject TrappedText;

    [SerializeField] private StaminaBar StaminaBar;

    private float speed = 10f;
    private float turnSpeed = 100f;

    public bool trapped;
    [SerializeField] private bool canRun;
    [SerializeField] private bool isRunning;
    
    [SerializeField] private int maxStamina = 100;
    [SerializeField] private int stamina;

    // Start is called before the first frame update
    void Start()
    {
        TrappedText = GameObject.Find("Trapped");
        TrappedText.SetActive(false);
        trapped = false;
        isRunning = false;
        canRun = true;
        stamina = maxStamina;
        StaminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        StaminaBar.SetStamina(stamina);
    }

    // If the player has collision with the trap and presses C, you can continue. A bypass for the voice recogniser.
   /* private void OnCollisionStay(Collision other)
    {
        if (Input.GetKeyDown(KeyCode.C) && other.gameObject.CompareTag("Trap"))
        {
            trapped = false;
            other.gameObject.SetActive(false);
            Debug.Log("test");
        }
        if (Input.GetKeyDown(KeyCode.C) && other.gameObject.CompareTag("Button"))
        {
            other.gameObject.GetComponent<Button>().WordRecognized(other.gameObject.GetComponent<Button>().magicalWord);
        }
    }
*/
    // IF the player enters collision with a trap, this changes it's state to trapped, and sets the
    // trapped text to true.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            trapped = true;
            TrappedText.SetActive(true);
        }
    }

    void PlayerMove()
    {
        if (trapped == false)
        {
            // If the forward button is pressed, move forward
            if (Input.GetKey(GameManager.instance.forward))
            {
                // Runs if shift is pressed, increases the speed and removes the stamina from the stamina bar.
                if (Input.GetKey(KeyCode.LeftShift) && canRun == true)
                {
                    speed = 30f;
                    stamina--;
                }
                transform.Translate(Time.deltaTime * speed * Vector3.forward);
            }
            // If the backward button is pressed, move backward
            if (Input.GetKey(GameManager.instance.backward))
            {
                speed = 5f;
                transform.Translate(Time.deltaTime * -speed * Vector3.forward);
            }
            
            // If shift is not pressed, sets speed to normal.
            if (Input.GetKeyUp(KeyCode.LeftShift))
                speed = 10f;

            // If the right button is pressed, move camera to the right
            if (Input.GetKey(GameManager.instance.right))
                transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);

            // If the left button is pressed, move camera to the left
            if (Input.GetKey(GameManager.instance.left))
                transform.Rotate(Time.deltaTime * -turnSpeed * Vector3.up);
        }
        
        // Refills the stamina bar
        if (isRunning == false && !canRun && stamina < maxStamina)
            stamina++;
        
        // Puts the player at normal speed when the stamina bar is empty
        else if (stamina <= 0)
        {
            speed = 10;
            canRun = false;
        }
        // If the stamina bar is full, the player can run again.
        else if (stamina >= maxStamina)
            canRun = true;
    }
}    
