using UnityEngine;
using System.Collections;

public class DifferentialLeaderFollower : MonoBehaviour {
	public float moveSpeed = 10f;
	public float turnSpeed = 10f;
	public int speed = 10;
	public GameObject IL_leader;
	public Transform mover;
	public float distance = 0.5f;
	private Vector3 destination;
	
	private Quaternion _lookRotation;
	private Vector3 _direction;
	
	private bool go = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.forward;
		Vector3 direction = (IL_leader.transform.position - transform.position).normalized;

		_direction = direction;
		_lookRotation = Quaternion.LookRotation (_direction);
		float angle = Vector3.Angle (direction, fwd);

			if (Vector3.Distance (transform.position, IL_leader.transform.position) < distance) {
				//mover.position = destination; //snap to destination
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				//Debug.Log("Distance: " + Vector3.Distance (transform.position, IL_leader.transform.position));
				
			} else {
				if (angle < 1f || angle == 90f) {
				
				//Vector3 direction = (IL_leader.transform.position - transform.position).normalized;
				rigidbody.velocity = direction * speed;
				Debug.Log ("Direction: " + direction);
			}
				else{
					transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, turnSpeed * Time.deltaTime);
				}
			}
	
	
}
}