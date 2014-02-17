using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public GameObject Leader;
	public GameObject Follower1;
	public GameObject Follower2;

	// Use this for initialization
	void Start () { //Start with kinematic Leader Follower
		disable (Follower1);
		disable (Follower2);
		disable (Leader);
		Leader.GetComponent <KinematicMouseController>().enabled 		= true;
		Follower1.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
		Follower2.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
	}
	
	// Update is called once per frame

	void Update () {
		if (Input.GetKey (KeyCode.J)) { //Switch to nearest neighbour mode
			disable (Follower1);
			disable (Follower2);
			disable (Leader);
			Leader.GetComponent <KinematicMouseController>().enabled 		= true;
			Follower1.GetComponent <NearestNeighbourKinematic>().enabled  	= true;
			Follower2.GetComponent <NearestNeighbourKinematic>().enabled  	= true;
				}
		if (Input.GetKey (KeyCode.K)) {//Switch to Virtual Structure
			disable (Follower1);
			disable (Follower2);
			disable (Leader);
			Leader.GetComponent <LeaderFollowerKinematic>().enabled 		= true;
			Follower1.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
			Follower2.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
		}
		if (Input.GetKey (KeyCode.L)) {//Switch to Differential Leader Follower
			disable (Follower1);
			disable (Follower2);
			disable (Leader);
			Leader.GetComponent <DifferentialMouseController>().enabled 	= true;
			Follower1.GetComponent <DifferentialLeaderFollower>().enabled  	= true;
			Follower2.GetComponent <DifferentialLeaderFollower>().enabled  	= true;
		}
	
	}

void disable (GameObject ob){
		MonoBehaviour[] scripts = ob.GetComponents<MonoBehaviour>();
		foreach(MonoBehaviour script in scripts)
		{
			script.enabled = false;
		}


		}
}
