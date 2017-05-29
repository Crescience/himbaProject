using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia {
	

	public class ButtonPopUp : MonoBehaviour, ITrackableEventHandler {

		private TrackableBehaviour mTrackableBehaviour;
		private bool mShowGUIButton = false;
		//private Rect mButtonRect = new Rect (0, 0, 100, 50);
		private string buttonText = "BUTTON";
		private AudioSource audioComp;
		public AudioClip audioClipSound;

		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		private void OnTrackingFound()
		{
			// change boolean to true to show the button
			mShowGUIButton = true;
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;

			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			// check that there is an AudioSource
			if (!mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>() != null) {
				// check if the AudioSource is playing
				if (!mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>().isPlaying) {
					// play the audio
					mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource> ().Play ();
				}
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}


		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}

		void OnGUI() {
			// calculate button width to be in the center
			// with some reasonable height
			int buttonWidth = Screen.width / 3;
			int buttonHeight = Screen.height / 10;
			int x = (Screen.width / 2) - (buttonWidth / 2);
			int y = Screen.height - buttonHeight;
			Rect mButtonRect = new Rect (x, y, buttonWidth, buttonHeight);
			// show the button
			if (mShowGUIButton) {
				GUI.Button (mButtonRect, buttonText);
			}
		}

	}
}
