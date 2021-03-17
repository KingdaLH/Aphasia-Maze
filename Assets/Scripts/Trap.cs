using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public string magicalWord;
    [SerializeField] private SpeechRecogniser SpeechRecogniser; 
    [SerializeField] private Text Say;
    
    private void Start()
    {
        //Finds the speechrecogniser and sets text to false
        SpeechRecogniser = GameObject.Find("SpeechRecogniser").GetComponent<SpeechRecogniser>();
        Say.gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        // If the player collides with the object, add value to the "Say" text, starts the recogniser and sets the
        // text active
        if (other.gameObject.CompareTag("Player"))
        {
            Say.text = "Say:" + magicalWord;
            Say.gameObject.SetActive(true);
            SpeechRecogniser.StartRecogniser();
            Debug.Log("I am online");
        }
    }

    // Sets the "Say" gameobject to false
    private void OnTriggerExit(Collider other)
    {
        Say.gameObject.SetActive(false);
    }

    // If the magicalWord is recognised, removes the false state from the player, stops the recogniser, and removes the say text from the screen,
    // And sets the current object to false
    public void WordRecognized(string recognized)
    {
        if (recognized == magicalWord)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().trapped = false;
            SpeechRecogniser.StopRecogniser();
            Say.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
