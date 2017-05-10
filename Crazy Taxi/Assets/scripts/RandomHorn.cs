using UnityEngine;
using System.Collections;

public class RandomHorn : MonoBehaviour {

    public float hornChance;
    private float counter = 0;
    public float timeBetweenHonks;
	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();

	
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter > timeBetweenHonks)
        {
            if (Random.value > hornChance)
                GetComponent<AudioSource>().Play();
            counter = 0;
        }
	}
}
	