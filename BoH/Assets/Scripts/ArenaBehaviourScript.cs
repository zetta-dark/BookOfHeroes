using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaBehaviourScript : MonoBehaviour {
	GameObject leftPage, rightPage;
	public GameObject book;
	public bool showIntro;
	
	// Use this for initialization
	void Start () {
		book.SetActive(true);
		
		// Set objects in book
		leftPage = GameObject.Find ("bone_front");
		rightPage = GameObject.Find ("bone_base");
		
		List<Transform> objects = new List<Transform>();
		
		foreach(Transform child in transform){ objects.Add(child); }
		
		foreach(Transform child in objects)
		{
			child.Rotate(90,0,0);
			if(child.position.x < 0){
				child.parent = rightPage.transform;
				child.Translate(0, -0.003f, 0);
			}
			else
			{
				child.Translate(-child.position.x*2, 0.006f, 0);
				child.Rotate(0,0,180);
				child.parent = leftPage.transform;
			}
			
		}
		
		// Hide arena area
		gameObject.renderer.enabled = false;
		
		if(!showIntro){
			book.animation["open"].time = 8.667f;
			GameObject.Find("Main Camera").animation["camera"].time = 8.667f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
