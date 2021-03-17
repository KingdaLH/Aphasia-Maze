using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
// Singleton for the player object
    #region Singleton

    public static PlayerManager instance;

    //locates the player at all time
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
