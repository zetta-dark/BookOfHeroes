using UnityEngine;
using System.Collections;

public class RangedWeaponScript : MonoBehaviour {
	
	public float atackSpeed;
	public float atack;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(atackSpeed,0,0)*Time.deltaTime);
	}
	
	void OnTriggerEnter (Collider other) {
		if(other.tag == "Red"){
				CharacterScript script = other.gameObject.GetComponent<CharacterScript>();
				script.HP = (int)(script.HP - atack * script.DEF_multiplier(script.DEF));
				print ("HP -->  " + script.HP);
		}	
	}
}
