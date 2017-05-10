using UnityEngine;
using System.Collections;

public class pointCompass : MonoBehaviour {
	private Vector3 target;
	private Transform compass;

	// Use this for initialization
	void Start () {
		compass = transform.Find("Compass");
	}
		
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = target - compass.transform.position;
		Vector3 forward = compass.transform.TransformDirection(Vector3.forward);
		float angle = Vector3.Angle (forward, targetDir);
		Quaternion rot = Quaternion.identity;

		if (angle < 90f)
			rot.eulerAngles = new Vector3 (0, -angle, 0);
		else
			rot.eulerAngles = new Vector3 (0, angle, 0);
		//Vector3 targetPoint= target-transform.position;
		//Quaternion targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up);
		//transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		compass.LookAt(target);

	}

	void changeTarget(Vector3 newTarget){
		target = newTarget;
	}
}