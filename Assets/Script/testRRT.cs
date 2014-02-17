using UnityEngine;
using System.Collections;

public class testRRT : MonoBehaviour {

	public GameObject source;
	public GameObject destination;
	UnityRandom urand = new UnityRandom(112233);
	// Use this for initialization
	void Start () {

		Vector3 start = source.transform.position;
		Vector3 dest = destination.transform.position;

		//Debug.DrawLine(start, dest, Color.red,5,false);
		//Debug.Log ("line: "+start+" "+dest);

		rrtAlgorithm rrt = new rrtAlgorithm ();
		ArrayList path = rrt.findBidirectionalPath (start, dest, 1000, 25);

		for (int i = 0; i<path.Count-1; i++) {
			Debug.DrawLine((Vector3)path[i], (Vector3)path[i+1], Color.red, 100.0f, false);
			Debug.Log ("line: "+path[i]+" "+path[i+1]);
		}

		/*
		for(int i =0; i<100; i++) {
			float val = myRnd(100, 1, 100);
			Debug.Log (val);
		}*/
	}

	private float myRnd (float point, float temp, float dim) {
		double p = point;
		float val = urand.Value (UnityRandom.Normalization.STDNORMAL, temp);
		return ((val*2*dim)-dim)+point;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
