using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseMenu.activeSelf) 
        { 
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }else if (Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeSelf)
            Continue();
    }

    public void Continue()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Back2MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
