using UnityEngine;
using System.Collections;

public class MoveCarsLeft : MonoBehaviour {
	float velocity = (float)1.5;
	float startpoint = -277;
	float endpoint = 60;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * velocity;
		if (transform.position.x >= endpoint) {
			transform.position = new Vector3(startpoint, transform.position.y,transform.position.z);
		}
	}
}
