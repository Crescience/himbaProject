using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmringDetailView : MonoBehaviour {

	[SerializeField]
	private Text armringDescription = null;
	private int mArmringID;
	private Component scriptText;

	// Use this for initialization
	void Start () {
		mArmringID = SceneNavigator.getParam ("armringID");
		armringDescription.text = "Description for Armring #" + mArmringID; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
