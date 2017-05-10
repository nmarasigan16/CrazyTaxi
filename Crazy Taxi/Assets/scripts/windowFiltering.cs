using UnityEngine;
using System.Collections;

public class windowFiltering : MonoBehaviour {

	private float closedWindowCutoff = 2500f;
	private float openWindowCutoff = 20000f;
	private float closedWindowVolume = 0.6f;
	private bool windowOpen = true;


	// Use this for initialization
	void Start () {
		//AudioLowPassFilter lpf = GetComponent<AudioLowPassFilter> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp ("h"))
		{
			windowOpen = !windowOpen;
			if (windowOpen) {
				AudioListener.volume = 1.0f;
				GetComponent<AudioLowPassFilter> ().cutoffFrequency = openWindowCutoff;
			}
			else
			{
				AudioListener.volume = closedWindowVolume;
				GetComponent<AudioLowPassFilter> ().cutoffFrequency = closedWindowCutoff;

				//GetComponent<AudioLowPassFilter> ().cutoffFrequency = 500;
			}

		}
	
	}
}
