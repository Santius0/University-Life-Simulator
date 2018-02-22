using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameFramework.GameObjects;

namespace LifeSimulator {
	
	public class AssaultEvent : GameEvent {
		private GameObject _player;
		BasePlayer assaulter;

		// Use this for initialization
		public override void Start () {
			_player = GameObject.Find ("Player");

			// create instance of assaulter
			BasePlayer assaulter = GameObject.Instantiate(Resources.Load("Sprites/assaulter/assaulter", typeof(BasePlayer))) as BasePlayer;
			assaulter.test ();
		}
		
		// Update is called once per frame
		void Update () {
			// calculate distance between player and assaulter
			// print(_player.ToString());

		}
	}

}
