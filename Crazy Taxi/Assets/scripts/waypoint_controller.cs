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
	}
	
	// Update is called once per frame
	void Update () {
		if (choose_new_pickup) {
			new_pickup ();
		}
	}

	public void destination_deactivated(float score){
		choose_new_pickup = true;
        player.GetComponent<score_script>().update_score(60 - Mathf.CeilToInt(score));
	}

    public void pickup_deactivated(bool timeout, GameObject destination)
    {
        if (timeout)
            choose_new_pickup = true;
        else
        {
            destination.GetComponent<destination_controller>().activate();
            updateCompass(destination.transform.position);
        }
    }

	void new_pickup(){
		int i = Mathf.CeilToInt(Random.Range (0.1f, (float)(pickups.Length))) - 1;
		GameObject pickup = pickups [i].gameObject;
		GameObject destination = pick_destination ();
		pickup.GetComponent<pickup_controller> ().activate (destination);
        updateCompass(pickup.transform.position);
		choose_new_pickup = false;
    }

	GameObject pick_destination(){
		int i = Mathf.CeilToInt(Random.Range (0.1f, (float)(destinations.Length))) - 1;
		return destinations [i].gameObject;
	}

    void updateCompass(Vector3 target)
    {
        player.GetComponent<pointCompass>().changeTarget(target);
    }
}
