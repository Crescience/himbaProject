using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia {
	

	public class ButtonPopUp : MonoBehaviour, ITrackableEventHandler {
		private TrackableBehaviour mTrackableBehaviour;
		private bool mShowGUIButton = false;
		private string buttonText = "BUTTON";
		private AudioSource audioComp;
		public AudioClip audioClipSound;
		private bool buttonRendered = false;
		private bool objectRecognized = false;

		// vars for animations
		private Vector3 originalScale;

		/*
		private GameObject AfricanCow_VeryDarkBrown;
		private float RotateSpeed = 5f;
		private float Radius = 0.1f;
		private Vector2 _centre;
		private float _angle; */


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

			objectRecognized = true;
			// change boolean to true to show the button
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
				//Debug.Log("Renderer " + component.name + " found");
				component.enabled = true;
				if (component.name == "Tree 4") {
					StartCoroutine (ScaleOverTime (component, 5));	
				} else if (component.name == "AfricanCow_VeryDarkBrown") {
					StartCoroutine (ScaleOverTime (component, 5));
				}
				else if (mTrackableBehaviour.transform.GetChild(0).name == "HimbaLadyContainer") {
					StartCoroutine (RotateOverTime (GameObject.Find("HimbaLadyContainer"), 5));
					Debug.Log("Game object is " + component.gameObject.name + " lost");
				} 
					
				//component.transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);

			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}
				
				// check if the AudioSource is playing
				if (!mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource>().isPlaying) {
					// play the audio
					mTrackableBehaviour.gameObject.GetComponentInChildren<AudioSource> ().Play ();
				}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}


		private void OnTrackingLost()
		{
			objectRecognized = false;
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			// code to enable animation
			Animation[] animationComponents = GetComponentsInChildren<Animation>();

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
				if (component.name == "Tree 4") {
					component.transform.localScale = originalScale;
				}
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



		IEnumerator RotateAroundOverTime(GameObject gameObject, int time) {
			float currentTime = 0.0f;
			do {
				gameObject.transform.RotateAround(gameObject.transform.position, gameObject.transform.up, Time.deltaTime * 90f);
				currentTime += Time.deltaTime;
				yield return null;
			} while (objectRecognized);
		}



	
		IEnumerator RotateOverTime(GameObject gameObject, int time) {
			Debug.Log("Rotate over time called!");
			float currentTime = 0.0f;
			do {
				gameObject.transform.Rotate(Vector3.up * Time.deltaTime);
				currentTime += Time.deltaTime;
				yield return null;
			} while (objectRecognized);
		}

			

		// handles scaling the renderer that was passed as a parameter to given scale
		IEnumerator ScaleOverTime(Renderer component, int time) {
			Debug.Log("ScaleOverTime called!");
			originalScale = component.transform.localScale;
			Vector3 originalPosition = component.transform.localPosition;
			Vector3 destinationScale = new Vector3 (0.04f, 0.04f, 0.04f);
			float currentTime = 0.0f;
			do {
				component.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
				//component.transform.RotateAround (originalPosition, component.transform.position, 1000);
				//component.transform.Rotate(0, 360, 0, Space.Self);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= time);
		}

		IEnumerator ScaleGameObjectOvertime(GameObject gameObject, int time) {
			originalScale = gameObject.transform.localScale;
			Vector3 originalPosition = gameObject.transform.localPosition;
			Vector3 destinationScale = new Vector3 (0.08f, 0.08f, 0.08f);
			float currentTime = 0.0f;
			do {
				gameObject.transform.localScale = Vector3.Lerp (originalScale, destinationScale, currentTime / time);
				currentTime += Time.deltaTime;
				yield return null;
			} while (currentTime <= time);
		}

			
		// handles rendering GUI objects & click events
		void OnGUI() {
			// renders button when an object is recognized
			if (objectRecognized) {
				// calculate button width to be in the center
				// with some reasonable height
				int buttonWidth = Screen.width / 3;
				int buttonHeight = Screen.height / 10;
				int x = (Screen.width / 2) - (buttonWidth / 2);
				int y = Screen.height - buttonHeight;
				Rect mButtonRect = new Rect (x, y, buttonWidth, buttonHeight);
				// show the button & handle click events on it
				if (GUI.Button (mButtonRect, buttonText)) {
					Debug.Log("BUtton CLICKED!");
					switchScene ();
				}
			}
		}

		// handles switching the scene based on the recognized object
		void switchScene() {
			SceneNavigator.Load ("MockScene", "armringID", 1);
		}
	}
}
