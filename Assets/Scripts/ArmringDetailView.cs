using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmringDetailView : MonoBehaviour {

	[SerializeField]
	private Text armringDescription = null;

	[SerializeField]
	private AudioSource braceletAudioDescription = null;

	[SerializeField]
	private BraceletModelSelector braceletModelSelector = null;

	private int mBraceletID;
	private Component scriptText;
	private Bracelet mBracelet;

	// Use this for initialization
	void Start () {
		
		mBraceletID = SceneNavigator.getParam ("braceletID");
		Debug.Log ("BraceletID = " + mBraceletID);
		mBracelet = new Bracelet (mBraceletID);

		armringDescription.text = mBracelet.getDescription ();
		braceletModelSelector.setActiveBraceletByID (mBraceletID);

		((AudioPlayer)braceletAudioDescription.GetComponent<AudioPlayer> ()).setBraceletID(mBraceletID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
