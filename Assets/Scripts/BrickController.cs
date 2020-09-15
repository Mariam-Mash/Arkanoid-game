using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour {

	public GameObject deathParticle;

	void OnCollisionEnter()
	{
		// call method to check the number of bricks hit and the state of the game
		GameManager.instance.HitBrick ();

		// instantiate the particle 
		Instantiate(deathParticle, transform.position, Quaternion.identity);

		Destroy (gameObject);
	}
}
