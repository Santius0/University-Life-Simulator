using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour {
	public Text numHours;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TrainFor(float hours){
		print (hours);
		// Sync slider and number
		numHours.text = hours.ToString();
	}
}
