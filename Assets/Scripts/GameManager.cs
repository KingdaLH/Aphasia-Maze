using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    #region Singleton
        
    public static GameManager instance;
        
    #endregion
    
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject DifficultyMenu;
    [SerializeField] private GameObject LevelSelector;
    [SerializeField] private GameObject ControlMenu;
    [SerializeField] private GameObject CreditsMenu;
    
    public string Difficulty;
    
    //Keycodes worden gekoppeld aan de acties van de speler en kunnen daarna door andere scripts gelezen worden.    
    public KeyCode forward {get; set;}
    public KeyCode backward {get; set;}
    public KeyCode left {get; set;}
    public KeyCode right {get; set;}

    void Awake()
    {
        //Singleton pattern
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        /*Koppelt elke keycode als de game start
        * Laad data van PlayerPrefs zodat als de speler afsluit, instellingen worden bewaard
        */
        //jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        Debug.Log(GameManager.instance.forward);
        backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        
        //DialogueTrigger.dialogueBox.gameObject.SetActive(false);
    }

    void Start()
    {
        // Checks if the current scene is the main menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Finds all menu's
            // StartMenu = GameObject.Find("StartMenu");
            // DifficultyMenu = GameObject.Find("DifficultyMenu");
            // LevelSelector = GameObject.Find("LevelSelector");
            // ControlMenu = GameObject.Find("ControlMenu");
            
            // Sets all menu's to active false
            DifficultyMenu.SetActive(false);
            LevelSelector.SetActive(false);
            // ControlMenu.SetActive(false);
            // CreditsMenu.SetActive(false);
        }
    }
    
    // Shows the difficulty select screen
    public void DifficultySelect() {StartMenu.SetActive(false); DifficultyMenu.SetActive(true);}
    
    // Shows the level select screen
    public void LevelSelect() {DifficultyMenu.SetActive(false); LevelSelector.SetActive(true);}
    
    // Shows the back button for the difficulty screen
    public void BackButtonDifficultySelect() {StartMenu.SetActive(true); DifficultyMenu.SetActive(false);}
    
    //shows the back button for the level select screen.
    public void BackButtonLevelSelector() {DifficultyMenu.SetActive(true); LevelSelector.SetActive(false);}
    public void ExitGame(){Application.Quit();}
    
    // Loads the level
    public void LoadLevel(string Level) {SceneManager.LoadScene(Difficulty + Level);}
    public void Controls() {StartMenu.SetActive(false); ControlMenu.SetActive(true);}
    public void BackButtonControls(){}
    public void Credits() {StartMenu.SetActive(false); CreditsMenu.SetActive(true);}
    public void BackButtonCredits(){}
}
