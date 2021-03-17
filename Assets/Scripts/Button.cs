using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    private static GameObject Door;
    [SerializeField] private string doorNr;
    public string magicalWord;
    [SerializeField] private SpeechRecogniser SpeechRecogniser;
    [SerializeField] private Text Say;
    
    // Finds the recogniser and the linked door. Deactivates the Say textfield
    void Start()
    {
        Door = GameObject.Find("Door " + doorNr);
        SpeechRecogniser = GameObject.Find("SpeechRecogniser").GetComponent<SpeechRecogniser>();
        Say.gameObject.SetActive(false);
    }
    
    // Starts the recogniser and activates the Say textfield if player enters the collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpeechRecogniser.StartRecogniser();
            Say.gameObject.SetActive(true);
            Say.text = "Say:" + magicalWord;
        }
    }
    
    // Stops the recogniser when player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        SpeechRecogniser.StopRecogniser();
        Say.gameObject.SetActive(false);
    }
    
    // If the recognisers recognised the word, and it's the same as magicWord, then it sets this gameobject
    // to false.
    public void WordRecognized(string recognized)
    {
        if (recognized == magicalWord)
            this.gameObject.SetActive(false);
    }
}
