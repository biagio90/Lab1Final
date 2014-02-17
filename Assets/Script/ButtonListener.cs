using UnityEngine;
using System.Collections;

public class ButtonListener : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			disableAllScript (player);
			player.GetComponent <DiscreteMouseController>().enabled  	= true;
		} else if (Input.GetKey (KeyCode.K)) {
			disableAllScript (player);
			player.GetComponent <KinematicMouseController>().enabled  	= true;
		} else if (Input.GetKey (KeyCode.A)) {
			disableAllScript (player);
			player.GetComponent <DifferentialMouseController>().enabled = true;
		} else if (Input.GetKey (KeyCode.F)) {
			disableAllScript (player);
			player.GetComponent <DynamicMouseController>().enabled  	= true;
		} else if (Input.GetKey (KeyCode.C)) {
			disableAllScript (player);
			player.GetComponent <CarMouseController>().enabled  		= true;
		}
	}

	private void disableAllScript(GameObject player) {
		MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
		foreach(MonoBehaviour script in scripts)
		{
			script.enabled = false;
		}
	}
}
