using UnityEngine;
using System.Collections;

public class pickup_controller : MonoBehaviour {
	private bool is_active;
	private float activeTime;
	private Transform npc_pos;
	private GameObject pad;
	private GameObject ind;
	private GameObject destination;
    private Object model;
    private waypoint_controller master;
    int rotspeed = 5;
    GameObject charac;
        


    // Use this for initialization
    void Start () {
        master = GameObject.Find("Controller").GetComponent<waypoint_controller>();
		pad = transform.Find ("Pad").gameObject;
		npc_pos = transform.Find ("Placement");
        ind = transform.Find("Indicator").gameObject;
		activeTime = Mathf.Infinity;
		pad.GetComponent<MeshRenderer> ().enabled = false;
		ind.GetComponent<MeshRenderer> ().enabled = false;
        charac = GameObject.Find("passenger");
    }
	
	// Update is called once per frame
	void Update () {
        if (is_active)
        {
            rotate_ind();
        }
	}

    void rotate_ind()
    {
        Quaternion rot = Quaternion.identity;
        float amount = 22.5f * Time.deltaTime * rotspeed;
        rot.eulerAngles = new Vector3(amount, 0, amount);
        ind.transform.rotation *= rot;
    }

	void deactivate(bool timeout){
		is_active = false;
		pad.GetComponent<MeshRenderer> ().enabled = false;
        ind.GetComponent<MeshRenderer>().enabled = false;
        master.pickup_deactivated(timeout, destination);
        Destroy(model);
    }

	IEnumerator stay_active(){
		yield return new WaitForSeconds (activeTime);
        //call master controller to have it activate a new point
        deactivate(true);
	}

	public void activate (GameObject newDestination){
		is_active = true;
		destination = newDestination;
		pad.GetComponent<MeshRenderer> ().enabled = true;
        ind.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine (stay_active ());
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(0, 0, 0);
        model = Instantiate(charac, npc_pos.transform.position, rot);
    }

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "playerCar") {
			if (is_active) {
				StopCoroutine (stay_active ());
				//col.gameObject.GetComponent<pointCompass> ().changeTarget (destination.transform.position);
				deactivate(false);
			}
		}
	}
}
