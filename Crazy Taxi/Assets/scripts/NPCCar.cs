using UnityEngine;
using System.Collections;

public class NPCCar : MonoBehaviour {

    public bool isLarge;
	private Rigidbody car;
	private bool x = true;
    private int turned_collisions;
	private int speed = 20;
	private int collisions;
	Vector3 forward = new Vector3 (1, 0, 0);

	// Use this for initialization
	void Awake () {
		car = GetComponent<Rigidbody> ();
		collisions = 0;
        turned_collisions = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move ();
	}

	void turn(string direction){
		Quaternion rot = Quaternion.identity;
		if (direction == "left") {
			rot.eulerAngles = new Vector3 (0, 0, -90);
		}
        if (direction == "right")
        {
            rot.eulerAngles = new Vector3(0, 0, 90);
        }
        if (direction == "around")
        {
            rot.eulerAngles = new Vector3(0, 0, 180);
        }
		transform.rotation *= rot;
	}

	void move(){
		Vector3 motionVector = transform.TransformDirection (forward);
		car.MovePosition (transform.position + motionVector * Time.deltaTime * speed);
	}

    void OnTriggerEnter(Collider col)
    {
        float delay = 0f;
        if (isLarge)
            delay = 1f;
        if (col.gameObject.tag == "border")
        {
            StartCoroutine(wait_turn(0f, "left"));
            StartCoroutine(wait_turn(.8f, "left"));
        }
        else if (col.gameObject.tag == "intersection")
        {
            if (turned_collisions != 0)
            {
                turned_collisions -= 1;
            }
            else
            {
                collisions += 1;
                if (collisions == 2)
                {
                    float should_turn = Random.value;
                    if (should_turn <= .5f)
                    {
                        StartCoroutine(wait_turn(delay, "right"));
                    }
                }
                else if (collisions == 3)
                {
                    float should_turn = Random.value;
                    if (should_turn <= .5f)
                    {
                        StartCoroutine(wait_turn(delay, "left"));
                    }
                    collisions = 0;
                }
            }
        }
    }

    IEnumerator wait_turn(float delay, string direction)
    {
        collisions = 0;
        yield return new WaitForSeconds(delay);
        collisions = 0;
        if (direction == "right")
        {
            turned_collisions = 1;
        }
        else
        {
            turned_collisions = 2;
        }
        turn(direction);

    }
}
