using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class resetScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return) || Input.GetKey ("enter")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
