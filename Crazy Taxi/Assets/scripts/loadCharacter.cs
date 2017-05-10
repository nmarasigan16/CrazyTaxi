using UnityEngine;
using System.Collections;

public class loadCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject charac = GameObject.Find ("passenger");
		Instantiate (charac, new Vector3 (0,0,0), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
