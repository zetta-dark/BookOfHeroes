using UnityEngine;
using System.Collections;

    public class Shoot2p : MonoBehaviour {
     
    public static bool turnOnEmitter = false;
     
    private void Update() { 
		if (Input.GetButton("Fire2")) {
			ParticleEmitter pEmitter = GetComponent<ParticleEmitter>( );
			pEmitter.Emit ();
        }
   }
}
