using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour {
	   
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.CompareTag("Ground"))
		{
			Vector3 newVelocity = new Vector3();
			newVelocity.x = Random.Range(-20, 20) * 6f;
			newVelocity.y = 20;
			newVelocity.z = Random.Range(-20, 20) * 6f;
			rb.AddForce(newVelocity);
		}
	}
}
