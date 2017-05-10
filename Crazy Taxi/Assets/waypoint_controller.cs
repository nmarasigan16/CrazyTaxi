using UnityEngine;
using System.Collections;

public class waypoint_controller : MonoBehaviour {

	private destination_controller[] destinations;
	private pickup_controller[] pickups;
	private GameObject player;
	private bool choose_new_pickup;

	// Use this for initialization
	void Start () {
		choose_new_pickup = true;
		player = GameObject.Find ("Avent");
		destinations = GameObject.Find ("Destinations").transform.GetComponentsInChildren<destination_controller> ();
		pickups = GameObject.Find ("Pickups").transform.GetComponentsInChildren<pickup_controller> ();
		for(int i = 0; i < pickups.Length; i++)
		{
			Debug.Log (destinations [i].gameObject.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (choose_new_pickup) {
			new_pickup ();
		}
	}

	public void destination_deactivated(){
		choose_new_pickup = true;
	}

	void new_pickup(){
		int i = Mathf.CeilToInt(Random.Range (0.1f, (float)(pickups.Length))) - 1;
		GameObject pickup = pickups [i].gameObject;
		GameObject destination = pick_destination ();
		pickup.GetComponent<pickup_controller> ().activate (destination);
		choose_new_pickup = false;
	}

	GameObject pick_destination(){
		int i = Mathf.CeilToInt(Random.Range (0.1f, (float)(destinations.Length))) - 1;
		return destinations [i].gameObject;
	}
}
