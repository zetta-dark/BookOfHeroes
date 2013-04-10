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
	public string meleeAttack = "b";
	public string rangedAttack = "n";
	public string specialAtack = "m";
	public Rigidbody rangeWeapon;
	
	private float timer = 0.0f;
	
	public  string up = "w";
	public  string down = "s";
	public  string left = "a";
	public  string right = "d";
	
	
	public float rotSpeed = 1; // rotation speed in degrees/second
	private Vector3 initialAngles;
	private Vector3 curAngles; // rotation relative to initial direction
	public float jumpSpeed = 8.0f;
    public float  gravity = 20.0f;
	
	private float initial_Y;
	private float current_Y;
	
	// Use this for initialization
	void Start () {
		initial_Y = transform.position.y;
		initialAngles = transform.eulerAngles;
 		curAngles = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		AtackRange();
		ControlCharacter();
		checkJump();
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
	}
	
	//Control movement
	public void GoUP(){
		transform.Translate(new Vector3(0,0,constantSpeed*Time.deltaTime*MSpeed),Space.World);
	}
	public void GoDown(){
		transform.Translate(new Vector3(0,0,-constantSpeed*Time.deltaTime*MSpeed),Space.World);
	}
	public void GoLeft(){
		transform.Translate(new Vector3(-constantSpeed*Time.deltaTime*MSpeed,0,0),Space.World);
		curAngles.y -= rotSpeed * Time.deltaTime;
		curAngles.y = Mathf.Clamp(curAngles.y, 180, 360);
		transform.eulerAngles = initialAngles + curAngles;
	}
	public void GoRight(){
		transform.Translate(new Vector3(constantSpeed*Time.deltaTime*MSpeed,0,0),Space.World);
		curAngles.y -= rotSpeed * Time.deltaTime;
		curAngles.y = Mathf.Clamp(curAngles.y, 0, 360);
		transform.eulerAngles = initialAngles;
	}
	
	//Melee atack
	void OnTriggerStay (Collider other) {
		CharacterScript script = other.gameObject.GetComponent<CharacterScript>();
		if(other.tag != gameObject.tag){
			if(Input.GetKey(meleeAttack)){
				script.HP = (int)(script.HP - Atack * DEF_multiplier(script.DEF));
			}	
		}
    }
	
	
	//Atack Range
	void AtackRange(){
		if(Input.GetKey(rangedAttack)){
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
	
	void checkJump(){
		if (Input.GetButton ("Jump")) {
	              current_Y = jumpSpeed;
	    }
        if (current_Y > initial_Y){
        	current_Y -= gravity * Time.deltaTime; // Apply gravity
			print ("2");
		}
		else {current_Y =  initial_Y;
			
		}
		
		  transform.position = new Vector3(0,current_Y,0);
	}
}