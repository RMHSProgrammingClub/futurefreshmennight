using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawn;
	public GameObject spawnParent;
	public int maxCount = 10;

	// Use this for initialization
	void Start () {
		StartCoroutine("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Spawn() {
		while (true)
		{
			if (spawnParent.transform.childCount < 10)
			{
				GameObject go = (GameObject)Instantiate(spawn);
				go.transform.parent = spawnParent.transform;
			}
			yield return new WaitForSeconds(1);
		}
	}
}
