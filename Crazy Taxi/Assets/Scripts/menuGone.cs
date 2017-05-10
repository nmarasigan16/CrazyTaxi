using UnityEngine;
using System.Collections;

public class menuGone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float forward_movement = Input.GetKey ("w") ? 1.0f : 0.0f;
		float backward_movement = Input.GetKey ("s") ? 1.0f : 0.0f;

		/*
        float forward_movement = Input.GetAxis("Oculus_GearVR_RIndexTrigger");
        float backward_movement = Input.GetAxis("Oculus_GearVR_LIndexTrigger");
        */

		if (forward_movement > 0 || backward_movement > 0) {
			gameObject.SetActive (false);
		}
	}
}
