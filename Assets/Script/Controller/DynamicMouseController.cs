using UnityEngine;
using System.Collections;

public class DynamicMouseController : MonoBehaviour {
	
	public float speed = 10;

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
			rigidbody.AddForce(Vector3.zero);
			go = true;
		}
		
		if (go) {
			float d = Vector3.Distance(transform.position, destination);
			Debug.Log("Distance: "+destination);
			if (d > 0.5) {
				Vector3 direction = (destination - transform.position).normalized;
				DirectionUtility.makeDynamicMove (rigidbody, direction, d, speed);
			} else {
				transform.position = destination;
				rigidbody.AddForce(Vector3.zero);
			}
		}
	}
}
