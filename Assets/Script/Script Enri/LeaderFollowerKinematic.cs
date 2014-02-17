using UnityEngine;
using System.Collections;

public class LeaderFollowerKinematic : MonoBehaviour {
	public GameObject IL_leader;
	public  float distance; 
	public int speed;
	public float timeNext = 0.08f;
	private float nextMove;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextMove) {
			nextMove = Time.time + timeNext;
			if (Vector3.Distance (transform.position, IL_leader.transform.position) < distance) {
						//mover.position = destination; //snap to destination
						rigidbody.velocity = Vector3.zero;
				//Debug.Log("Distance: " + Vector3.Distance (transform.position, IL_leader.transform.position));
					
				} else {
						//mover.position = Vector3. MoveTowards(mover.transform.position, destination, Time.deltaTime * 10);
						Vector3 direction = (IL_leader.transform.position - transform.position).normalized;
						rigidbody.velocity = direction * speed;
						Debug.Log ("Direction: " + direction);
				}
		}
		//Debug.DrawLine(transform.position, IL_leader.transform.position, Color.red, 5,false);
	}
	

}
