using UnityEngine;
using System.Collections;

public class npc_controller : MonoBehaviour {
    Animator anim;
    bool hailing;
    private string[] animClipNameGroup;
    Vector3 destination;




	// Use this for initialization
	void Start () {

        animClipNameGroup = new string[] {
            "Teat_01",
            "Basic_Walk_01",
            "Basic_Walk_02",
            "Etc_Walk_Zombi_01"

        };

        anim = gameObject.GetComponent<Animator>();
        hailing= false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hailing)
        {
            move();
        }

	}

    void chooseAnimation()
    {

    }

    void move()
    {
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
    }

    void hailTaxi()
    {
        anim.Play(animClipNameGroup[0]);
        Vector3 up = new Vector3(0, 2.5f, 0);
        transform.position = transform.position + up;
        //generate destination
        //pass to some trigger?
    }
    
    void stopHailing()
    {

    }

    void turn(string direction)
    {
        Quaternion rot = Quaternion.identity;
        if (direction == "left")
        {
            rot.eulerAngles = new Vector3(0, -90, 0);
        }
        if (direction == "right")
        {
            rot.eulerAngles = new Vector3(0, 90, 0);
        }
        if (direction == "around")
        {
            rot.eulerAngles = new Vector3(0, 0, 180);
        }
        transform.rotation *= rot;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "street_corner")
        {
            float should_turn = Mathf.Round(Random.value * 100 + 1);
            if(should_turn > 70)
            {
                StartCoroutine(wait_turn(1, "left"));
            }
            else if(should_turn > 40)
            {
                StartCoroutine(wait_turn(1f, "right"));
            }

        }
    }

    IEnumerator wait_turn(float time, string direction)
    {
        yield return new WaitForSeconds(time);
        turn(direction);
    }
}
