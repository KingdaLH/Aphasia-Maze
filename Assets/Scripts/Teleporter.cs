using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject Reciever;
    [SerializeField] private string TeleporterNr;
    [SerializeField] private Vector3 PosToTeleportTo;
    private void Start()
    {
        Reciever = GameObject.Find("Receiver " + TeleporterNr);
        PosToTeleportTo = (Reciever.transform.position);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = PosToTeleportTo;
            PosToTeleportTo = Reciever.transform.position;
        }
    }
}