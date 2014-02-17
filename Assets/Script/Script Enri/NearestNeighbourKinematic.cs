using UnityEngine;
using System.Collections;

public class NearestNeighbourKinematic : MonoBehaviour {

	public int speed;
	public float gendistance;
	public float tolerance;
	// Use this for initialization
	void Start () {
		//rigidbody.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = FindClosestEnemy ();
		move.y = 0.0f;
		//transform.position = transform.position + Time.deltaTime * move * speed;
		//rigidbody.velocity = rigidbody.velocity + move * speed;
		rigidbody.velocity = move * speed;
	}

	Vector3 FindClosestEnemy() {
		float d_max = gendistance + tolerance;
		float d_min = gendistance - tolerance;
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("sphere");
		//float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		Vector3 move = Vector3.zero;
		//Debug.Log ("gos dimension " + gos.Length);
		foreach (GameObject go in gos) {
			Vector3 diff = position - go.transform.position;
			//float curDistance = diff.magnitude;
			float curDistance = Vector3.Distance (position,go.transform.position);
			//Debug.Log ("distance " + diff);
			Vector3 truemove = diff.normalized * (curDistance-gendistance);
			if ((curDistance > d_max || curDistance < d_min) && curDistance != 0)
			move = move - (truemove);
			//Debug.Log ("cur distance " + curDistance);

			//float curDistance = diff.sqrMagnitude;
			/*
			if (curDistance < distance) {
			closest

			}*/
		}
		return move;
	}
}
