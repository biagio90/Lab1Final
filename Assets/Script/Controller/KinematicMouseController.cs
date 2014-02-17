using UnityEngine;
using System.Collections;

public class KinematicMouseController : MonoBehaviour {
	
	public float speed = 10;
	public int dimSearch = 25;

	private Vector3 destination = Vector3.zero;
	private bool go = false;
	private ArrayList path;
	private int path_index;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			destination = DirectionUtility.getMouseDirection();
			if (destination != Vector3.zero ) {
				destination.y = transform.position.y;
				go = true;
				float time = System.DateTime.Now.Second;
				path = (new rrtAlgorithm()).findBidirectionalPath (transform.position, destination, 1000, dimSearch);
				printPath(path);
				Debug.Log ("Time: "+(System.DateTime.Now.Second-time));
				path_index = 1;
			}
		}
		
		if (go) {
			destination = (Vector3) path[path_index];
			float d = Vector3.Distance(transform.position, destination);
			//Debug.Log("position: "+transform.position+" Destination: "+destination+" distance: "+d);
			//Debug.Log("Distance: "+path.Count);
			if (d > 0.5) {
				Vector3 direction = (destination - transform.position).normalized;
				DirectionUtility.makeKinematicMove (rigidbody, direction, speed);
			} else {
				rigidbody.velocity=Vector3.zero;
				transform.position = destination;
				path_index++;
				if(path_index == path.Count ) go = false;
				Debug.Log ("Path index: "+path_index);
			}
		}
	}

	private void printPath (ArrayList path) {
		for (int i = 0; i<path.Count-1; i++) {
			Debug.DrawLine((Vector3)path[i], (Vector3)path[i+1], Color.red, 100.0f, false);
			//Debug.Log ("line: "+path[i]+" "+path[i+1]);
		}
	}
	/*private Vector3 nextInPath (ArrayList path, int path_index) {

	}*/
}
