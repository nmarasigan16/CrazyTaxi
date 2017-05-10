using UnityEngine;
using System.Collections;

public class RandomHorn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.value > 0.99f)
		GetComponent<AudioSource>().Play();
	}
}
	