using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameFramework.GameStructure.Levels;

public class GameLoop : MonoBehaviour {
	private int semester;
	private int week;	// a semester has 16 weeks

	// Use this for initialization
	void Start () {
		print ("Setting Timescale"); // TODO: check the pause dialog to maybe not have to do this
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//if (LevelManager.Instance.IsLevelRunning && (health > 100)) {
		if (LevelManager.Instance.IsLevelRunning && false) {
			LevelManager.Instance.GameOver (false);	// win. If false then lose

			// TODO: change from being static and put health in player
			//health = 50f;
		}
	}

	public static void increaseHealth(float x){
		//health += x;
		//print (health);
	}
}
