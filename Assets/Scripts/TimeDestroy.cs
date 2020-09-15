using UnityEngine;
using System.Collections;

// Class to destroy a particle after its duration. So it avoid 
// the particle to keep alive in the scene.

public class TimeDestroy : MonoBehaviour {

	private float durationOfParticle = 1f;

	void Start()
	{
		Destroy (gameObject, durationOfParticle);
	}
}
