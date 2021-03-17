using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject levelComplete;

    [SerializeField] private PlayerMovement PlayerMovement;
    // Start is called before the first frame update
    void Start()
    {
        levelComplete = GameObject.Find("LevelComplete");
        levelComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelComplete.SetActive(true);
            PlayerMovement.trapped = true;
        }
    }
}
