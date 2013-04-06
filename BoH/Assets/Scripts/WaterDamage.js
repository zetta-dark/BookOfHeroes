#pragma strict

    public var water : GameObject;
    var waterTime:float;
    var wet : boolean;
    var timer : int = 0;
    var maxTimer : int;
    var tex : UnityEngine.Texture;
     
    function Update(){
    	if (wet == true) {
    		var cutoff : float = renderer.materials[1].GetFloat("_Cutoff");
    		timer = timer + 1;
    		if (cutoff < 1 && timer >= maxTimer) {
        		renderer.materials[1].SetFloat("_Cutoff", cutoff + 0.1);
        		timer = 0;
        	}
    	}
    }
    
    function PutOutWater(){
    	wet = false;
    }
    
    function OnParticleCollision(other:GameObject){
    	if(other.gameObject.tag == "Wet"){
    		var waterEffect = Instantiate(water, gameObject.transform.position, Quaternion.identity);
    		waterEffect.transform.parent = gameObject.transform;
    		Destroy(waterEffect, waterTime);
    		
    		wet = true;
    		renderer.materials[0].SetTexture("_Texture1", tex);
    	}
    }