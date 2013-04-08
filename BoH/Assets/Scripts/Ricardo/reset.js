#pragma strict

function Start () {

}

function Update () {
	if (Input.GetButton ("Jump")) {
    	Application.LoadLevel(0);
    }
}