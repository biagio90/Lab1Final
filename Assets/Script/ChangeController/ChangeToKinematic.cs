using UnityEngine;
using System.Collections;

public class ChangeToKinematic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("TRIGGER");
		if (other.attachedRigidbody) {
			other.GetComponent <DiscreteMouseController>().enabled 		= false;
			other.GetComponent <KinematicMouseController>().enabled 	= true;
			other.GetComponent <DynamicMouseController>().enabled 		= false;
			other.GetComponent <DifferentialMouseController>().enabled 	= false;
			other.GetComponent <CarMouseController>().enabled 			= false;
		}
	}
}
