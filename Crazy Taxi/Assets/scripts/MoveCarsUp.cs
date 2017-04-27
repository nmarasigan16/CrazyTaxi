using UnityEngine;
using System.Collections;

public class MoveCarsUp : MonoBehaviour {
	float velocity = (float)-1.5;
	float endpoint = 360;
	float startpoint = 710;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position += Vector3.forward * velocity;
		if (transform.position.z <= endpoint) {
			transform.position = new Vector3(transform.position.x, transform.position.y,startpoint);
		}
	}
}