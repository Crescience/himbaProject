using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	[SerializeField]
	private AudioClip[] audioClips;

	[SerializeField]
	private AudioSource audioSource = null;

	public void setBraceletID(int pId) {
		audioSource.clip = audioClips [pId];
		Debug.Log ("Audioclip selected");
	}

	public void onClick_AudioButton() {
		if (!audioSource.isPlaying) {
			audioSource.Play ();
		} else {
			audioSource.Stop ();
		}
	}
}
