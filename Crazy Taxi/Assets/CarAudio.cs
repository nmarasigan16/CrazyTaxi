using UnityEngine;
using System.Collections;

public class CarAudio : MonoBehaviour {

	private float currentSpeed = 0;
	private float pitch = 0;
	private float maxSpeed = 0;
	private float minPitch = 0.4f;
	private float minVolume = 0.5f;
	private float volume = 0;

	// Use this for initialization
	void Start () {
	
		MotionScript motion = GetComponent<MotionScript>();
		maxSpeed = motion.maxSpeed;
		pitch = minPitch;
		volume = minVolume;
	}

	// Update is called once per frame
	void Update () {

		MotionScript motion = GetComponent<MotionScript>();
		currentSpeed = motion.currentSpeed;


		pitch = currentSpeed / maxSpeed;

		pitch = pitch * pitch;
		if (pitch < minPitch) {
			volume = 2 * pitch;
			volume = Mathf.Clamp(volume, minVolume, 1.0f);
			GetComponent<AudioSource> ().volume = volume;
			pitch = minPitch;
		}

		GetComponent<AudioSource>().pitch = pitch;
	}



}
