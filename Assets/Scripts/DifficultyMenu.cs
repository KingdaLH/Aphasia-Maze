using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public void Tutorial(){SceneManager.LoadScene("Tutorial");}
    public void Easy(){SceneManager.LoadScene("Easy Level 1");}
    public void Medium(){SceneManager.LoadScene("Easy Level 2");}
    public void Hard(){SceneManager.LoadScene("Hard Level 1");}
}
