using UnityEngine;
using System.Collections;

public class MotionScript : MonoBehaviour {
    private CharacterController characterController;
    private int acceleration = 5;
    private int maxSpeed = 75;
    private int maxReverse = 20;
    private int rotSpeed = 70;
    private float decelerationFactor = (float)(-.05);
    private float braking_factor = (float)(-.3);
    private float currentSpeed = 0;


    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movementVector = updateMovement();
        // Should maybe store quaternion for use in steering wheel rotation
        if(currentSpeed != 0)
            transform.rotation *= updateRotation();
        currentSpeed = Mathf.Clamp(currentSpeed, -maxReverse, maxSpeed);
        characterController.Move(movementVector * Time.deltaTime);
	}

    Vector3 updateMovement()
    {
        float forward_movement = Input.GetAxis("Oculus_GearVR_RIndexTrigger");
        float backward_movement = Input.GetAxis("Oculus_GearVR_LIndexTrigger");
        if(forward_movement != 0)
        {
            Debug.Log(forward_movement);
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
        Vector3 forward = new Vector3(1, 0, 0);
        return transform.TransformDirection(forward) * currentSpeed;
    }

    Quaternion updateRotation()
    {
        Quaternion rot = Quaternion.identity;
        float roll = 0;
        roll = Input.GetAxis("Oculus_GearVR_LThumbstickX") * (Time.deltaTime * rotSpeed);
        rot.eulerAngles = new Vector3(0, roll, 0);
        return rot;
    }
}
