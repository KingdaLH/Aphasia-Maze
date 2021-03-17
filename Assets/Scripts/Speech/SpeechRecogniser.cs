using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecogniser : MonoBehaviour
{
    [SerializeField] private List<string> keywords = new List<string>();
    protected string word;
    [SerializeField] private ConfidenceLevel confidence = ConfidenceLevel.Low;

    [SerializeField] private GameObject[] traps;
    [SerializeField] private GameObject[] buttons;
    
    protected PhraseRecognizer recognizer;

    //Takes all of the possible words from the buttons/traps and adds them to the list
    private void Awake()
    {
        foreach (var t in traps)
            keywords.Add(t.GetComponent<Trap>().magicalWord);
        foreach (var b in buttons)
            keywords.Add(b.GetComponent<Button>().magicalWord);
    }

    void Start()
    {
        // Initiates the program when the keywords string is not null
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords.ToArray(), confidence);
            
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        }
    }

    // Starts the recogniser
    public void StartRecogniser()
    {
        recognizer.Start();

        if (recognizer.IsRunning)
            Debug.Log("recognizer is running!");
    }

    //Outputs the word that is recognized and sends it to all of the buttons and traps
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        foreach (var t in traps)
            t.GetComponent<Trap>().WordRecognized(word);

        foreach (var B in buttons)
            B.GetComponent<Button>().WordRecognized(word);
        Debug.Log("You said: <b>" + word + "</b>");
    }
    // Stops the recogniser
    public void StopRecogniser()
    {
        recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
        recognizer.Stop();
        
        if (!recognizer.IsRunning)
            Debug.Log("recognizer has stopped!");
    }
}
    
