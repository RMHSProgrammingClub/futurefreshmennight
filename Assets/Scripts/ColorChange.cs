using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	Color c1;
	Color c2;
	MeshRenderer mr;

	// Use this for initialization
	void Start () {
		c1 = new Color(1, 116/225, 116/255, 1);
		c2 = new Color(169/255, 122/255, 122/255, 1);
		mr = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Color newColor = Color.Lerp(c1, c2, Mathf.PingPong(Time.time, 1));
		mr.material.color = newColor;
	}
}
