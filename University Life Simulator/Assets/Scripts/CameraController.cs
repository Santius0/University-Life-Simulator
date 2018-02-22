using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		// print (offset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Runs every frame but guaranteed to run after all items have been processed in update
	void LateUpdate(){
		transform.position = player.transform.position + offset;
	}
}
