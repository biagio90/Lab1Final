using UnityEngine;
using System.Collections;

public class CarMouseController : MonoBehaviour {
	
	public int speed = 10;
	public int brakeSpeed = 1000;
	public float maxSpeed = 50;
	public float maxAngle = 40;
	
	public WheelCollider wheelFR;
	public WheelCollider wheelFL;
	public WheelCollider wheelBR;
	public WheelCollider wheelBL;

	private Vector3 destination = Vector3.zero;
	private bool go = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			destination = DirectionUtility.getMouseDirection();
			destination.y = transform.position.y;
			go = true;
		}
		
		if (go) {
			float d = Vector3.Distance (transform.position, destination);
			Vector3 direction = (destination - transform.position).normalized;

			if(d < 0.5){
				breakCar(0.1f);
				moveCar(direction, 0);
			} else {
				moveCar(direction, d);
				steerCar(direction);
				breakCar(d);
			}
		}
	}


	void steerCar (Vector3 direction) {
		float dirSign = (Vector3.Cross (transform.forward, direction).normalized).y > 0 ? 1 : -1;
		float angle = Vector3.Angle (transform.forward, direction);
		if ( angle > maxAngle ) angle = maxAngle ;
		//Debug.Log ("Angle: "+dirSign);
		
		wheelFR.steerAngle = angle * dirSign;
		wheelFL.steerAngle = angle * dirSign;
	}
	
	void moveCar (Vector3 direction, float distance) {
		float dirSign = 1.0f;
		if ( Vector3.Angle (direction, transform.forward) > 90 ) dirSign = -1.0f ;
		
		float motor = speed * distance;
		if (motor > maxSpeed) motor = maxSpeed;
		
		wheelFR.motorTorque = motor * dirSign;
		wheelFL.motorTorque = motor * dirSign;
		//wheelBR.motorTorque = motor * dirSign;
		//wheelBL.motorTorque = motor * dirSign;
		
	}
	
	void breakCar(float distance){
		wheelFR.brakeTorque = brakeSpeed / (distance*distance);
		wheelFL.brakeTorque = brakeSpeed / (distance*distance);
		wheelBR.brakeTorque = brakeSpeed / (distance*distance);
		wheelBL.brakeTorque = brakeSpeed / (distance*distance);
	}

}
