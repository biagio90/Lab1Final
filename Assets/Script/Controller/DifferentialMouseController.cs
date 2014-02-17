using UnityEngine;
using System.Collections;

public class DifferentialMouseController : MonoBehaviour {
	
	public float speed = 10;
	public float turnSpeed = 10;

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
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			go = true;
		}
		
		if (go) {
			float d = Vector3.Distance(transform.position, destination);
			Debug.Log("Distance: "+destination);
			if (d > 0.5) {
				DirectionUtility.makeDifferentialMove (transform, rigidbody, destination, speed, turnSpeed);
			} else {
				transform.position = destination; //snap to destination
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}

		}
	}
}
