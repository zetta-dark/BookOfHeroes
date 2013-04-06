#pragma strict

function Start () {

}

function Update () {

}
    function OnParticleCollision (other : GameObject) {
    	if(other.tag =="FireWaterable"){
    	Destroy(other);
    }
    	if(other.tag =="FireFlower"){
    		other.GetComponent(FireDamage).PutOutFire();
    		other.GetComponent(FireDamage).HealFire();
    	}
    }