#pragma strict

function Start () {

}

function Update () {

}
    function OnParticleCollision (other : GameObject) {
    if(other.tag =="WetFireable"){
    Destroy(other);
    }
    if(other.tag =="FireFlower"){
    other.GetComponent(WaterDamage).PutOutWater();
    }
    }