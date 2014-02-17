using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	public int level = 1;
	void OnTriggerStay(Collider other) {
		Application.LoadLevel (level);
	}

		
}
