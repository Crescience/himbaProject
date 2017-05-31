using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraceletModelSelector : MonoBehaviour {

	[SerializeField]
	private GameObject[] bracelet3DModels = null;

	public void setActiveBraceletByID(int pId) {
		for (int i = 0; i < bracelet3DModels.Length; i++) {
			if (i + 1 == pId) {
				bracelet3DModels [i].SetActive (true);
			}
			else {
				bracelet3DModels [i].SetActive (false);
			}
		}
	}
}
