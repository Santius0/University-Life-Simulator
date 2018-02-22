using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameFramework.UI.Dialogs.Components;
using CnControls;

namespace LifeSimulator {
	
	public class BasePlayer : MonoBehaviour {

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
		}


		public void test(string s = "default"){
			print ("Player Test Successful" + s);
		}
			
	}
}