using UnityEngine;
using System.Collections;

public class MotionScript : MonoBehaviour {
	private Rigidbody rb;
    private int acceleration = 5;
    public int maxSpeed = 50;
    private int maxReverse = 20;
    private int rotSpeed = 60;
    private float decelerationFactor = (float)(-.05);
    private float braking_factor = (float)(-.3);
    public float currentSpeed = 0;
	private Vector3 movementVector;


    // Use this for initialization
    void Awake () {
		rb = GetComponent<Rigidbody>();
		movementVector = Vector3.zero;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        movementVector = updateMovement();
        // Should maybe store quaternion for use in steering wheel rotation
        if(currentSpeed != 0)
            transform.rotation *= updateRotation();
        currentSpeed = Mathf.Clamp(currentSpeed, -maxReverse, maxSpeed);
        move(movementVector);
	}

    Vector3 updateMovement()
    {

		float forward_movement = Input.GetKey ("w") ? 1.0f : 0.0f;
		float backward_movement = Input.GetKey ("s") ? 1.0f : 0.0f;

        /*
        float forward_movement = Input.GetAxis("Oculus_GearVR_RIndexTrigger");
        float backward_movement = Input.GetAxis("Oculus_GearVR_LIndexTrigger");
        */
        if(forward_movement != 0)
        {
			currentSpeed = currentSpeed + forward_movement * acceleration;
        }
        if(backward_movement != 0)
        {
            if(currentSpeed > 0)
            {
                currentSpeed = currentSpeed + braking_factor * acceleration;
            }
            else
            {
                currentSpeed = currentSpeed + -backward_movement * acceleration;
            }
        }

        if((forward_movement == 0 && backward_movement == 0) && currentSpeed > 0)
        {
            currentSpeed = currentSpeed + decelerationFactor * acceleration;
            if(currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
		else if((forward_movement == 0 && backward_movement == 0) && currentSpeed < 0)
		{
			currentSpeed = currentSpeed - decelerationFactor * acceleration;
			if(currentSpeed > 0)
			{
				currentSpeed = 0;
			}
		}
        Vector3 forward = new Vector3(1, 0, 0);
        return transform.TransformDirection(forward) * currentSpeed;
    }

    Quaternion updateRotation()
    {
		Quaternion rot = Quaternion.identity;
		float roll = 0;

		float roll_left = Input.GetKey ("a") ? -1.0f : 0.0f;
		float roll_right = Input.GetKey ("d") ? 1.0f : 0.0f;
		if (roll_right != 0)
			roll = roll_right * (Time.deltaTime * rotSpeed);
		else
			roll = roll_left * (Time.deltaTime * rotSpeed);

        //roll = Input.GetAxis("Oculus_GearVR_LThumbstickX") * (Time.deltaTime * rotSpeed);
        rot.eulerAngles = new Vector3(0, roll, 0);
        return rot;
    }

	void move(Vector3 motionVector){
		rb.MovePosition (transform.position + motionVector * Time.deltaTime);
	}
		

}
