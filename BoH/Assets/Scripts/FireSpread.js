#pragma strict

    var growthInterval : float; // seconds
    var growthRate : float; // meters/second
    var particleDensity : int; // # particles/meter

    function Start() {
    while(transform.localScale.x < 10) {
    yield WaitForSeconds (growthInterval);
    if (particleEmitter.emit) {
    transform.localScale += new Vector3(growthRate * growthInterval,
    0f,
    growthRate * growthInterval);
     
    particleEmitter.minEmission = (growthRate * growthInterval + transform.localScale.x) *
    particleDensity;
     
    particleEmitter.maxEmission = particleEmitter.minEmission;
    }
    }
}