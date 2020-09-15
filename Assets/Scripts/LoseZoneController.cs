using UnityEngine;
using System.Collections;

public class LoseZoneController : MonoBehaviour {

	void OnTriggerEnter(Collider col)

	{
		GameManager.instance.LoseLife ();
	}

	void OnCollisionEnter()

	{
		GameManager.instance.LoseLife ();
	}
}
