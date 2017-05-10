using UnityEngine;
using System.Collections;

public class pickup_controller : MonoBehaviour {
	private bool is_active;
	private float activeTime;
	private Transform npc_pos;
	private GameObject pad;
	private GameObject destination;



	// Use this for initialization
	void Start () {
		pad = transform.Find ("Pad").gameObject;
		npc_pos = transform.Find ("Placement");
		activeTime = 100f;
		pad.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void deactivate(){
		Debug.Log ("deactivate");
		is_active = false;
		pad.GetComponent<MeshRenderer> ().enabled = false;
	}

	IEnumerator stay_active(){
		yield return new WaitForSeconds (activeTime);
		//call master controller to have it activate a new point
		deactivate();
	}

	public void activate (GameObject newDestination){
		is_active = true;
		destination = newDestination;
		pad.GetComponent<MeshRenderer> ().enabled = true;
		StartCoroutine (stay_active ());
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("collision");
		if (col.gameObject.tag == "playerCar") {
			Debug.Log (is_active);
			if (is_active) {
				StopCoroutine (stay_active ());
				destination.GetComponent<destination_controller> ().activate (col.gameObject);
				//col.gameObject.GetComponent<pointCompass> ().changeTarget (destination.transform.position);
				deactivate();
			}
		}
	}
}
