using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecogniser : MonoBehaviour
{
    private string[] keywords = new string[] {"up", "down", "left", "right", "stop", "destroy", "end"};
    protected string word = "stop";
    [SerializeField] private ConfidenceLevel confidence = ConfidenceLevel.Low;
    private float speed = 1.0f;

    public Text results;
    public GameObject target;

    protected PhraseRecognizer recognizer;

    // Start is called before the first frame update
    void Start()
    {
        //finds the PlayerController GameObject and puts it in target
        target = GameObject.Find("PlayerController");
        //Starts the recognizer and initiates the program when the keywords string is not null
        if (keywords != null)
        {
            Debug.Log(keywords);
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
        else
        {
            speed = 0f;
        }
        
        if (recognizer.IsRunning)
        {
            Debug.Log("recognizer is running!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.transform.position.x;
        var y = target.transform.position.y;

        switch (word)
        {
            case "up":
                y += speed;
                break;
            case "down":
                y -= speed;
                break;
            case "left":
                x -= speed;
                break;
            case "right":
                x += speed;
                break;
            case  "stop":
                x = 0f;
                y = 0f;
                break;
            case "destroy":
                Destroy(target);
                break;
            case "end":
                Application.Quit();
                break;
        }
        target.transform.position = new Vector3(x, y, 0);
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }
}
    
