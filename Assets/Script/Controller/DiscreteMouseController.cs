using UnityEngine;
using System.Collections;

public class DiscreteMouseController : MonoBehaviour {

	public float speed = 1;
	public float delay = 0.1f;

	private float nextTime = 0.0f;

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

		if (go && Time.time > nextTime) {
			nextTime = Time.time + delay;

			float d = Vector3.Distance(transform.position, destination);
			Debug.Log("Distance: "+destination);
			if (d > speed) {
				Vector3 direction = (destination - transform.position).normalized;
				DirectionUtility.makeDiscreteMove (transform, direction, speed);
			}
		}
	}


}
