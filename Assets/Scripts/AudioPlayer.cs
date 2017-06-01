using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	[SerializeField]
	private AudioClip[] audioClips;

	[SerializeField]
	private AudioSource audioSource = null;

	public bool setBraceletID(int pId) {
		if (audioClips [pId - 1] != null) {
			audioSource.clip = audioClips [pId - 1];
			if (audioSource == null) {
				Debug.Log("Audioplayer: audiosource is null!");
			}
			Debug.Log ("Audioclip selected");
			return true;
		} else
			return false;

	}

	public void onClick_AudioButton() {
		if (!audioSource.isPlaying) {
			audioSource.Play ();
		} else {
			audioSource.Stop ();
		}
	}
}
