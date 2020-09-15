using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed;

	// Update is called once per frame
	void Update () {

		Vector3 nextPosition = transform.position;
		float moveHorizontal = nextPosition.x + (Input.GetAxis ("Horizontal") * paddleSpeed);

		nextPosition.x = Mathf.Clamp(moveHorizontal, -4f, 4f);

		transform.position = nextPosition;
	}
}
