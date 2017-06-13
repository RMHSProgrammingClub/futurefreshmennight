using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = new Vector3(0, 0, 0);
		Vector3 newRotation = new Vector3(0, 0, 0);
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			newPosition += new Vector3(this.transform.forward.x/3,this.transform.forward.y/3,this.transform.forward.z/3);
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			newPosition -= new Vector3(this.transform.forward.x/3,this.transform.forward.y/3,this.transform.forward.z/3);
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			newRotation.y -= 1;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			newRotation.y += 1;
		}
		if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.PageUp))
		{
			newRotation.x -= 1;
		}
		if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageDown))
		{
			newRotation.x += 1;
		}

		transform.position += newPosition;

		transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles + newRotation);
	}
}
