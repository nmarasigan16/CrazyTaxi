using UnityEngine;
using System.Collections;

public class destination_controller : MonoBehaviour {
	private GameObject pad;
	private GameObject npc_pos;
	private GameObject playerCar;
	private bool is_active;
	private float start_time;
	private float score_factor = .1f;
	private float time_active = Mathf.Infinity; //could be used to time

	// Use this for initialization
	void Start () {
		pad = transform.Find ("Pad").gameObject;
		pad.GetComponent<MeshRenderer> ().enabled = false;
		npc_pos = transform.Find ("Placement").gameObject;
		is_active = false;
		score_factor = .1f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void deactivate(bool completed){
		if (completed) {
			int score = (int)(Mathf.Round((Time.time - start_time) * score_factor));

			//add score

			//spawn npc that walks
		} else {
			//call fail method in playerCar
		}
		is_active = false;
	}

	IEnumerator wait_for_arrival () {
		yield return new WaitForSeconds (time_active);
		deactivate (false);
	}

	public void activate (GameObject player){
		pad.GetComponent<MeshRenderer> ().enabled = true;
		start_time = Time.time;
		playerCar = player;
		is_active = true;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "playerCar") {
			deactivate (true);
		}
	}
}
