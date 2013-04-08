using UnityEngine;
using System.Collections;

public class CharacterAuxScript : MonoBehaviour {
	
	private CharacterScript script;
	public float rotSpeed = 1; // rotation speed in degrees/second
	private Vector3 initialAngles;
	private Vector3 curAngles; // rotation relative to initial direction
	
	// Use this for initialization
	void Start () {
		initialAngles = transform.eulerAngles;
 		curAngles = Vector3.zero;
		script = transform.parent.GetComponent("CharacterScript") as CharacterScript;
	}
	
	// Update is called once per frame
	void Update () {
		  
		if(Input.GetKey(script.left)){
			curAngles.y -= rotSpeed * Time.deltaTime;
			curAngles.y = Mathf.Clamp(curAngles.y, 180, 360);
			transform.eulerAngles = initialAngles + curAngles;
		}
		else if (!Input.GetKey(script.up)){
			transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
	}
}