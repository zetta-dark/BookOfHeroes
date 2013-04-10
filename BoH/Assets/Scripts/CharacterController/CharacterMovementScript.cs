using UnityEngine;
using System.Collections;
using SmoothMoves;

public class CharacterMovementScript : MonoBehaviour {
	
	public BoneAnimation characterAnimation;
	private CharacterController controller;
	private float speed = 6.0f;
	private float jumpSpeed = 8.0f;
	private float gravity = 20.0f;
 	private Vector3 moveDirection = Vector3.zero;
	private bool isgrounded = true;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("a")|| Input.GetKeyDown("w")||Input.GetKeyDown("s") || Input.GetKeyDown("d"))
		{	
			characterAnimation.Play("Run");	
		}
		if(Input.GetKeyUp("a") || Input.GetKeyUp("w")||Input.GetKeyUp("s") || Input.GetKeyUp("d"))
		{
			characterAnimation.Play("Stand");	
		}
		if(Input.GetKeyDown("i"))
		{
			characterAnimation.Play("m_atack");	
		}
		if(Input.GetKeyUp("i"))
		{
			characterAnimation.Play("Stand");	
		}
		if(Input.GetKeyDown("o"))
		{
			characterAnimation.Play("r_atack");	
		}
		if(Input.GetKeyUp("o"))
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
	
	//make sure u replace "floor" with your gameobject name.on which player is standing
/*	void OnCollisionEnter(Collision theCollision){
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
