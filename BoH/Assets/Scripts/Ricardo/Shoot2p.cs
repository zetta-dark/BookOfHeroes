using UnityEngine;
using System.Collections;

    public class Shoot : MonoBehaviour {
     
    public static bool turnOnEmitter = false;
     
    private void Update() { 
		if (Input.GetButton ("Fire1")) {
			ParticleEmitter pEmitter = GetComponent<ParticleEmitter>( );
			pEmitter.Emit ();
        }
   }
}
