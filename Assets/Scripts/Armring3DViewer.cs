using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armring3DViewer : MonoBehaviour {

	float rotSpeed = 20;
	public GameObject virtualBraceletArea;
	public Camera canvasCamera;
	private RectTransform virtualBraceletAreaRectTransform;

	void Start() {
		virtualBraceletAreaRectTransform = virtualBraceletArea.GetComponent<RectTransform> ();
	}

	void Update() {

		if (Input.touchCount > 0 
			&& Input.GetTouch (0).phase == TouchPhase.Moved
			&& RectTransformUtility.RectangleContainsScreenPoint (virtualBraceletAreaRectTransform, Input.GetTouch (0).position, canvasCamera)) {


			// Get movement since the last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// calculate rotation
			float rotX = touchDeltaPosition.x * rotSpeed * Mathf.Deg2Rad;
			float rotY = touchDeltaPosition.y * rotSpeed * Mathf.Deg2Rad;

			// rotate object
			transform.Rotate (Vector3.up * -rotX, Space.World);
			transform.Rotate (Vector3.right * rotY, Space.World);
		}
	}
}
