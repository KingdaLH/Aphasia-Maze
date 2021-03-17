using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLevelComplete : MonoBehaviour
{
    public void Back2MainMenu() { SceneManager.LoadScene("MainMenu");}
}
