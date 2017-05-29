using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia {
	

	public class ButtonPopUp : MonoBehaviour, ITrackableEventHandler {

		private TrackableBehaviour mTrackableBehaviour;
		private bool mShowGUIButton = false;
		private bool isRendered = false;
		//private Rect mButtonRect = new Rect (0, 0, 100, 50);
		private string buttonText = "BUTTON";
		private AudioSource audioComp;
		public AudioClip audioClipSound;

		// vars for animations
		private GameObject AfricanCow_VeryDarkBrown;
		private float RotateSpeed = 5f;
		private float Radius = 0.1f;
		private Vector2 _centre;
		private float _angle;


		void Start()
		{
			//_centre = AfricanCow_VeryDarkBrown.transform.position;
			//AfricanCow_VeryDarkBrown = GameObject.Find ("AfricanCow_VeryDarkBrown");

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		void Update()
		{
			/* another try at looping around animations
			_angle += RotateSpeed * Time.deltaTime;
			var offset = new Vector2 (Mathf.Sin (_angle), Mathf.Cos (_angle)) * Radius;
			transform.forward = _centre + offset; */

			/* The cow just keeps going and going and going and going.....
			if (isRendered) {
				Debug.Log("Should start moving the COW!");
				AfricanCow_VeryDarkBrown.transform.position += AfricanCow_VeryDarkBrown.transform.forward * 50.0f * Time.deltaTime;
			} */
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
			isRendered = true;
			mShowGUIButton = true;
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			// code to enable animation
			Animation[] animationComponents = GetComponentsInChildren<Animation>();

			foreach (Animation component in animationComponents) {
				component.Play ();
			}


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
			if (mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>() != false) {
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
			isRendered = false;
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			// code to enable animation
			Animation[] animationComponents = GetComponentsInChildren<Animation>();

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

			foreach (Animation component in animationComponents) {
				component.Stop ();
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
