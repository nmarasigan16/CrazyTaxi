using UnityEngine;
using System.Collections;

public class destination_controller : MonoBehaviour {
	private GameObject pad;
	private GameObject npc_pos;
	private bool is_active;
	private float start_time;
	private float score_factor = .1f;
	private float time_active = Mathf.Infinity; //could be used to time
    private GameObject ind;
    int rotspeed = 5;
    private waypoint_controller master;

    // Use this for initialization
    void Start () {
        master = GameObject.Find("Controller").GetComponent<waypoint_controller>();
        pad = transform.Find ("Pad").gameObject;
		npc_pos = transform.Find ("Placement").gameObject;
        ind = transform.Find("Indicator").gameObject;
        is_active = false;
		score_factor = .1f;
        toggleMeshRenderer(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (is_active)
            rotate_ind();
	}

	void deactivate(bool completed){
        Debug.Log(completed);
        if (completed) {
            Debug.Log(Time.time - start_time);
			int score = (int)(Mathf.Round((Time.time - start_time) * score_factor));

            //add score
            master.destination_deactivated(score);
            //spawn npc that walks
            toggleMeshRenderer(false);
		} else {
			//call fail method in playerCar
		}
		is_active = false;
	}
    void rotate_ind()
    {
        Quaternion rot = Quaternion.identity;
        float amount = 22.5f * Time.deltaTime * rotspeed;
        rot.eulerAngles = new Vector3(amount, 0, amount);
        ind.transform.rotation *= rot;
    }

    IEnumerator wait_for_arrival () {
		yield return new WaitForSeconds (time_active);
		deactivate (false);
	}

	public void activate (){
        toggleMeshRenderer(true);
		start_time = Time.time;
		is_active = true;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "playerCar") {

			deactivate (true);
		}
	}

    void toggleMeshRenderer(bool enabled)
    {
        pad.GetComponent<MeshRenderer>().enabled = enabled;
        ind.GetComponent<MeshRenderer>().enabled = enabled;
    }
}
