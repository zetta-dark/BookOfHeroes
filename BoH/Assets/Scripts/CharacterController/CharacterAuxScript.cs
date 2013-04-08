using UnityEngine;
using System.Collections;

public class CharacterAuxScript : MonoBehaviour {

	private CharacterScript script;

	
	
	// Use this for initialization
	void Start () {

			script = transform.parent.GetComponent("CharacterScript") as CharacterScript;
	}
	
	// Update is called once per frame
	void Update () {
		  
		if(Input.GetKey(script.up)){
			transform.localRotation = Quaternion.Euler(new Vector3(0, 20, 0));
		}
		else if (!Input.GetKey(script.up)){
			transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
	
	}
}
