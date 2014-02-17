using UnityEngine;
using System.Collections;

public class MouseKinematicPlayerControllerEnri : MonoBehaviour {

	public int speed = 10;

	public Transform mover;
	public float distance = 0.5f;
	private Vector3 destination = Vector3.zero;

	private Vector3 movePoint = new Vector3(0,0.9f,0);
	private bool go = false;

	// Use this for initialization
	void Start () {
		mover = transform;
		destination = mover.position;
	}
	
	// Update is called once per frame
	void Update () {

		//when left mouse button is pressed
		if (Input.GetMouseButtonDown(0))
		{
			destination = getDirection();
			destination.y = transform.position.y;
			go = true;
		}

		if(go)
		// move the object toward the destination
		if (Vector3.Distance (mover.position, destination) < distance) 
			//mover.position = destination; //snap to destination
			rigidbody.velocity =  Vector3.zero;
		else {
			//mover.position = Vector3. MoveTowards(mover.transform.position, destination, Time.deltaTime * 10);
			Vector3 direction = (destination - transform.position).normalized;
			rigidbody.velocity =  direction * speed;
			//Debug.Log ( "Direction: " + direction);
		}
	}

	Vector3 getDirection () {
		Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition)); //create the ray
		RaycastHit hit; //create the var that will hold the information of where the ray hit
		
		if (Physics.Raycast(ray, out hit)) //did we hit something?
			if (hit.transform.name == "Plane")
				return hit.point; //set the destinatin to the vector3 where the ground was contacted
		return destination;
	}
}
