using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameFramework.GameObjects;

using GameFramework.UI.Dialogs.Components;

namespace LifeSimulator {
	
	public class BuildingController : MonoBehaviour {
		protected DialogInstance DialogInstance;
		private Slider _trainingHours;
		private Player Player;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnTriggerEnter2D(Collider2D triggerCollider){
			Player = triggerCollider.gameObject.GetComponent<Player> ();	// connect Player object
			print (triggerCollider.tag);	// should always be Player
			print (tag);
			showDialogBox ();
		}

		void showDialogBox(){
	//		DialogManager.Instance.Show (title: "Hello World",
	//			text: "Some sample text here",
	//			doneCallback: DoneCallback,
	//			dialogButtons: DialogInstance.DialogButtonsType.OkCancel
	//		);

			DialogInstance = DialogManager.Instance.Show (prefabName: "Train",
				doneCallback: DoneCallback);

			_trainingHours = GameObjectHelper.GetChildComponentOnNamedGameObject<Slider>(DialogInstance.Target, "Slider_TrainTime", true);
		}

		public virtual void DoneCallback(DialogInstance dialogInstance){
			if (dialogInstance.DialogResult == DialogInstance.DialogResultType.Ok) {
				DialogManager.Instance.ShowInfo ("Ok Pressed on " + tag + " for  " + _trainingHours.value + "hours: ");

                // Fast Forward Time x hours
                TimeManager.Instance.addTime((int)_trainingHours.value);


                if (tag == "Gym") {
					print ("Increasing Player Physique");
				} else if (tag == "Resturant") {
					print ("Increasing Player Health");
				} else if (tag == "Library") {
					print ("Increasing Player Book Smarts");
				} else if (tag == "Club") {
					print ("Increasing Player Social Stading");
					Player.increasePhysique (_trainingHours.value);
				}

			} else
	            DialogManager.Instance.ShowInfo("Cancel Pressed");
	    }


	}
}