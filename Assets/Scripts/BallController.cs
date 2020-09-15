using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float scale;

	private bool isFirstShoot;
	private Rigidbody ballRigidBody;

	void Awake() {
		isFirstShoot = true;
		ballRigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
	
		// force will be applied only once. So no need to be in FixedUpdate
		if(Input.GetButton("Fire1") && isFirstShoot) 
		{
			InitilizeBall ();
			isFirstShoot = false;
		}
	}

	void InitilizeBall()
	{

		// remove pre setup of the ball that made it to follow the brick
		ballRigidBody.isKinematic = false;
		transform.parent = null;

		// add force to the rigidBody
		Vector3 direction = new Vector3 (1f, 1f, 0f);
		ballRigidBody.AddForce (direction * scale, ForceMode.Force);	

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("LoseZone"))
		{
			Destroy (gameObject);
		}
	}
}
