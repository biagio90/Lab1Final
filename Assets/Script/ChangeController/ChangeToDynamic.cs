using UnityEngine;
using System.Collections;

public class ChangeToDynamic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("TRIGGER");
		if (other.attachedRigidbody) {
			other.GetComponent <DiscreteMouseController>().enabled  	= false;
			other.GetComponent <KinematicMouseController>().enabled 	= false;
			other.GetComponent <DynamicMouseController>().enabled 		= true;
			other.GetComponent <DifferentialMouseController>().enabled 	= false;
			other.GetComponent <CarMouseController>().enabled 			= false;
		}
	}
}
