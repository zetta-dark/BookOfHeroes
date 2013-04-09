using UnityEngine;
using System.Collections;

public class PaperBehaviourScript : MonoBehaviour {
	bool flipped;
	GameObject leftTurner, rightTurner, arena;
	bool showIntro;
	
	// Use this for initialization
	void Start () {
		leftTurner = GameObject.Find("turner_left");
		rightTurner = GameObject.Find("turner_right");
		showIntro = ((ArenaBehaviourScript)GameObject.Find ("arena").GetComponent("ArenaBehaviourScript")).showIntro;
		Debug.Log(showIntro);
		if(!showIntro){
			animation.Play();
			animation["flip"].time = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(showIntro && !flipped &&
			(rightTurner.transform.position.x != 0 && Mathf.Abs(transform.position.x - rightTurner.transform.position.x) < 0.1f) ||
			(leftTurner.transform.position.x != 0 && Mathf.Abs(transform.position.x - leftTurner.transform.position.x) < 0.1f))
		{
			animation.Play();
			flipped = true;
		}
	}
}
