using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void OnClick_Scan()
	{
		SceneManager.LoadScene ("basic");
		Debug.Log("Clicked Scan-Button");
	}

	public void OnClick_Browse() {
		SceneManager.LoadScene ("ArmringBrowseScene");
		Debug.Log("Clicked Browse-Button");
	}

	public void OnClick_BackToMainMenu() {
		SceneManager.LoadScene ("MainMenu");
		Debug.Log("Clicked Back-Button");
	}

	public void OnClick_GoToArmringDetailView(int pId) {
		SceneNavigator.Load ("ArmringDetailView", "braceletID", pId);
		Debug.Log("Clicked Back-Button");
	}
}
