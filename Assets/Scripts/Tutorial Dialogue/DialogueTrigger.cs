using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	[SerializeField]private GameObject dialogueBox;

	// Finds the dialogue manager and calls the StartDialogue function
	public void TriggerDialogue ()
	{
		dialogueBox.gameObject.SetActive(true);
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		this.gameObject.SetActive(false);
	}

}
