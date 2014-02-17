using UnityEngine;
using System.Collections;

public class DirectionUtility
{
	public DirectionUtility ()
	{
	}

	public static Vector3 getMouseDirection () {
		Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition)); //create the ray
		RaycastHit hit; //create the var that will hold the information of where the ray hit
		
		if (Physics.Raycast(ray, out hit)) //did we hit something?
			if (hit.transform.tag == "sourface")
				return hit.point; //set the destinatin to the vector3 where the ground was contacted
		return Vector3.zero;
	}

	public static void makeDiscreteMove (Transform transform, Vector3 direction, float speed){
		transform.position = transform.position + speed * direction.normalized;
	}

	public static void makeKinematicMove (Rigidbody rigidbody, Vector3 direction, float speed){
		rigidbody.velocity = direction * speed;
	}
	
	public static void makeDynamicMove (Rigidbody rigidbody, PID pid, Vector3 origin, Vector3 dest){
		rigidbody.AddForce( pid.regulation(origin, dest) );
	}

	public static void makeDifferentialMove (Transform transform, Rigidbody rigidbody, Vector3 destination, float speed, float turnSpeed){
		//float d = Vector3.Distance(transform.position, destination);
		Vector3 direction = (destination - transform.position).normalized;
		Quaternion _lookRotation = Quaternion.LookRotation (direction);
		float angle = Vector3.Angle (direction, transform.forward);

		if (angle < 1f || angle == 90f) {
			rigidbody.velocity = direction * speed;
		} else {
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, turnSpeed * Time.deltaTime);
			
		}
	}

	public static void makeCarMove (Rigidbody rigidbody, Vector3 direction, float speed){
		rigidbody.AddForce( direction * speed * 100.0f * Time.deltaTime );
	}


}
