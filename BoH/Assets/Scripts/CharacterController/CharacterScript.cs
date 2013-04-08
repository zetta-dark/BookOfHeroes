using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	
	public int HP = 100;
	public int DEF = 20;
	public int MSpeed = 1; //movementSpeed
	public int Atack = 30;
	public int AtackSpeed = 1;
	private int constantSpeed = 4; // base movement speed that all characters have before MSpeed be applied
	private Vector3 moveDirection;
	public string atackMelee = "b";
	public string atackRange = "n";
	public string specialAtack = "m";
	public Rigidbody rangeWeapon;
	
	private float timer = 0.0f;
	
	public  string up = "w";
	public  string down = "s";
	public  string left = "a";
	public  string right = "d";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AtackRange();
		ControlCharacter();
	}
	
	
	//just animation
	public void ControlCharacter(){	
		if(Input.GetKey(up)){
			GoUP();
		}
		if(Input.GetKey(down)){
			GoDown();
		}
		if(Input.GetKey(left)){
			GoLeft();
		}
		if(Input.GetKey(right)){
			GoRight();
		}
		
		if(Input.GetKey(atackMelee)){
				
				
		}
		else if(Input.GetKey(atackRange)){
				
				
		}
		else if(Input.GetKey(specialAtack)){
				
				
		}
	}
	
	//Control movement
	public void GoUP(){
		transform.Translate(new Vector3(0,0,constantSpeed*Time.deltaTime*MSpeed));
	}
	public void GoDown(){
		transform.Translate(new Vector3(0,0,-constantSpeed*Time.deltaTime*MSpeed));
	}
	public void GoLeft(){
		transform.Translate(new Vector3(-constantSpeed*Time.deltaTime*MSpeed,0,0));
	}
	public void GoRight(){
		transform.Translate(new Vector3(constantSpeed*Time.deltaTime*MSpeed,0,0));
	}
	
	//Melee atack
	void OnTriggerStay (Collider other) {
		CharacterScript script = other.gameObject.GetComponent<CharacterScript>();
		if(other.tag != gameObject.tag){
			if(Input.GetKey(atackMelee)){
				script.HP = (int)(script.HP - Atack * DEF_multiplier(script.DEF));
			}	
		}
    }
	
	
	//Atack Range
	void AtackRange(){
		if(Input.GetKey(atackRange)){
			timer -= Time.deltaTime;
			if (timer < 0)
    		{	
				Rigidbody clone;
       			clone = Instantiate(rangeWeapon, transform.position, transform.rotation) as Rigidbody;
				timer = AtackSpeed;
			}
		}
	}
	

	public float DEF_multiplier(int def){
		float val = 0.0f;
		if(def > 0)
			val = 100 * 1/(100 + def);
		else if(def <= 0)
			val = 2 - 100 * 1/(100 + def);
		return val;
	}
}