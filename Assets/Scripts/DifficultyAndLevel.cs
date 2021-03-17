using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyAndLevel : MonoBehaviour
{
    private GameManager GameManager;
    
    [SerializeField] private string difficulty;
    [SerializeField] private int LevelNr;
    public void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();    
    }

    public void DifficultyButton()
    {
        GameManager.Difficulty = difficulty;
        GameManager.LevelSelect();
    }

    public void LoadLevel()
    {
        string Level = " Level " + LevelNr;
        GameManager.LoadLevel(Level);
    }
}
