#pragma strict

    public var fire : GameObject;
    var fireTime:float;
    var onFire : boolean;
    var timer : int = 0;
    var healTimer : int = 0;
    var maxTimer : int;
    var maxHealTimer : int;
    var tex : UnityEngine.Texture;
     
    function Update(){
    	if (onFire == true) {
    		var cutoff : float = renderer.materials[1].GetFloat("_Cutoff");
    		timer = timer + 1;
    		if (cutoff < 1 && timer >= maxTimer) {
        		renderer.materials[1].SetFloat("_Cutoff", cutoff + 0.1);
        		timer = 0;
        	}
    	}
    }
    
    function PutOutFire(){
    	onFire = false;
    }
    
    function HealFire(){
    	if (onFire == false) {
    		var cutoff : float = renderer.materials[1].GetFloat("_Cutoff");
    		healTimer = healTimer + 1;
    		if (cutoff > 0.1 && healTimer >= maxHealTimer) {
        		renderer.materials[1].SetFloat("_Cutoff", cutoff - 0.1);
        		healTimer = 0;
        	}
    	}
    }
    function OnParticleCollision(other:GameObject){
    	if(other.gameObject.tag == "Fire"){
    		var fireEffect = Instantiate(fire, gameObject.transform.position, Quaternion.identity);
    		fireEffect.transform.parent = gameObject.transform;
    		Destroy(fireEffect, fireTime);
    		onFire = true;
    		renderer.materials[0].SetTexture("_Texture1", tex);
    	}
    }