using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	// This is all for the editor
	public string name;

	[TextArea(10, 20)]
	public string[] sentences;

}
