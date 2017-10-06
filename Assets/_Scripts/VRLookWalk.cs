using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {

	// VR Main Camera
	public Transform vrCamera;
	//Angle at which walk/stop will be triggered (X value of main camera)
	public float toggleAngle = 20.0f;
	// How fast to move
	public float speed = 3.0f;
	// Should I move forward or now
	public bool moveForward;
	// CharacterController script
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		// Find the CharacterController
		cc = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// Check to see if the head has rotated down to the toggle angle, but not more than 60 degrees down
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 60.0f) {
			// Move forward
			moveForward = true;
		}
		else {
			// Stop moving
			moveForward = false;
		}

		// Check to see if I should move
		if (moveForward) {
			// Find the forward direction
			Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
			// Tell CharacterController to move forward
			cc.SimpleMove(forward * speed);
		}
	}
}
