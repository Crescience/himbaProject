using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// supposed to handle moving in a circle!
public class Oscillator : MonoBehaviour {
	float timeCounter = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;

		float x = Mathf.Cos (timeCounter);
		float y = Mathf.Sin (timeCounter);
		float z = 0;

		transform.position = new Vector3 (x, y, z);
	}
}
