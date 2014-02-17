using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public GameObject Leader;
	public GameObject Follower1;
	public GameObject Follower2;
	public GameObject Formation;
	public GameObject planeFront;
	public GameObject planeP1;
	public GameObject planeP2;
	public GameObject camera;
	// Use this for initialization
	void Start () { //Start with kinematic Leader Follower
		disable (Follower1);
		disable (Follower2);
		disable (Leader);
		Leader.GetComponent <KinematicMouseController>().enabled 		= true;
		Follower1.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
		Follower2.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
		camera.GetComponent <CameraController>().player = 		Leader;
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
			//be sure to have camera on the leader
			camera.GetComponent <CameraController>().player = 		Leader;
				}
		if (Input.GetKey (KeyCode.K)) {//Switch to Virtual Structure
			disable (Follower1);
			disable (Follower2);
			disable (Leader);
			Formation.SetActive(true);
			Leader.GetComponent <LeaderFollowerKinematic>().enabled 		= true;
			Follower1.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
			Follower2.GetComponent <LeaderFollowerKinematic>().enabled  	= true;
			//set correct leaders to each object
			Leader.GetComponent <LeaderFollowerKinematic>().IL_leader = planeFront;
			Follower1.GetComponent <LeaderFollowerKinematic>().IL_leader =	planeP1;
			Follower2.GetComponent <LeaderFollowerKinematic>().IL_leader =	planeP2;
			//set the same distance
			Leader.GetComponent <LeaderFollowerKinematic>().distance = 		1;
			Follower1.GetComponent <LeaderFollowerKinematic>().distance =	1;
			Follower2.GetComponent <LeaderFollowerKinematic>().distance =	1;
			//Set the camera on the formation and not anymore on the leader
			camera.GetComponent <CameraController>().player = 		Formation;
		}
		if (Input.GetKey (KeyCode.L)) {//Switch to Differential Leader Follower
			disable (Follower1);
			disable (Follower2);
			disable (Leader);
			Leader.GetComponent <DifferentialMouseController>().enabled 	= true;
			Follower1.GetComponent <DifferentialLeaderFollower>().enabled  	= true;
			Follower2.GetComponent <DifferentialLeaderFollower>().enabled  	= true;
			//be sure to have camera on the leader
			camera.GetComponent <CameraController>().player = 		Leader;
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
