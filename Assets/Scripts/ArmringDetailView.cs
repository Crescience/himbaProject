using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmringDetailView : MonoBehaviour {

	[SerializeField]
	private Text mTextArmringDescription = null;

	[SerializeField]
	private AudioPlayer mAudioPlayer = null;

	[SerializeField]
	private GameObject mBtnPlayAudio = null;

	[SerializeField]
	private BraceletModelSelector mBraceletModelSelector = null;

	private int mBraceletID;
	private Bracelet mBracelet;

	// Use this for initialization
	void Start () {

		// Get BraceletID passed by calling scene
		mBraceletID = SceneNavigator.getParam ("braceletID");
		Debug.Log ("BraceletID = " + mBraceletID);

		// Initializing objects for specified braceletID
		mBracelet = new Bracelet (mBraceletID);
		mTextArmringDescription.text = mBracelet.getDescription ();
		mBraceletModelSelector.setActiveBraceletByID (mBraceletID);

		if (!mAudioPlayer.setBraceletID (mBraceletID)) {
			// if the audioplayer could not set sucessfully for specified id -> disable the play audio button
			mBtnPlayAudio.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
