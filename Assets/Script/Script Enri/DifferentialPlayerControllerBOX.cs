using UnityEngine;
using System.Collections;

public class DifferentialPlayerControllerBOX : MonoBehaviour {

	public float moveSpeed = 10f;
	public float turnSpeed = 100f;

	// Use this for initialization
	void Start () {
		//renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.DownArrow))
			transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
	}
}
