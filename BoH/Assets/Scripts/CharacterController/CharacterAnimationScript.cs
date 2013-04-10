using UnityEngine;
using System.Collections;
using SmoothMoves;

public class CharacterAnimationScript : MonoBehaviour {
	
	public BoneAnimation characterAnimation;
	private CharacterScript script;
	private float speed = 20.0f;
	private float jumpSpeed = 15.0f;
	private float gravity = 30.0f;
 	private Vector3 moveDirection = Vector3.zero;
	private bool isgrounded = true;
	
	// Use this for initialization
	void Start () {
		script = transform.GetComponent("CharacterScript") as CharacterScript;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(script.right)|| Input.GetKeyDown(script.up)||Input.GetKeyDown(script.down) || Input.GetKeyDown(script.left))
		{	
			characterAnimation.Play("Walk");	
		}
		if(Input.GetKeyUp(script.right) || Input.GetKeyUp(script.left)||Input.GetKeyUp(script.up) || Input.GetKeyUp(script.down))
		{
			characterAnimation.Play("Stand");	
		}
		if(Input.GetKeyDown(script.meleeAttack))
		{
			characterAnimation.Play("Melee_Attack");
		}
		if(Input.GetKeyUp(script.meleeAttack))
		{
			characterAnimation.Play("Stand");
		}
		if(Input.GetKeyDown(script.rangedAttack))
		{
			characterAnimation.Play("Ranged_Attack");	
		}
		if(Input.GetKeyUp(script.rangedAttack))
		{
			characterAnimation.Play("Stand");	
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			characterAnimation.Play("Jump");	
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			characterAnimation.Play("Stand");	
		}
		
		CharacterController controller = GetComponent<CharacterController>();
		if(controller.isGrounded)
	    {
	        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        moveDirection = transform.TransformDirection(moveDirection);
	        moveDirection *= speed;
	 
	        if (Input.GetButton ("Jump")) {
	            moveDirection.y = jumpSpeed;
	        }
	    }
	 
		    // Apply gravity
		    moveDirection.y -= gravity * Time.deltaTime;
		 
		    // Move the controller
		    controller.Move(moveDirection * Time.deltaTime);
		
}
	/*
	//make sure u replace "floor" with your gameobject name.on which player is standing
	void OnCollisionEnter(Collision theCollision){
	    if(theCollision.gameObject.name == "Floor")
	    {
	        isgrounded = true;
	    }
	}
	 
	//consider when character is jumping .. it will exit collision.
	void OnCollisionExit(Collision theCollision){
	    if(theCollision.gameObject.name == "Floor")
	    {
	        isgrounded = false;
	    }
	}*/
}
