using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameFramework.UI.Dialogs.Components;
using CnControls;

using GameFramework.GameStructure;
using GameFramework.GameStructure.Levels;
using GameFramework.GameStructure.Levels.ObjectModel;
// using GameFramework.GameStructure.Players.ObjectModel;
using GameFramework.GameStructure.GameItems.ObjectModel;

namespace LifeSimulator {
	
	public class Player : BasePlayer {
		private float physique = 0f;
		private float bookSmarts = 0f;
		private float streetSmarts = 0f;
		private float socialLife = 0f;

		private static float health = 50f;
		private float money = 0f;
		private float sleepDeprivation = 0f;

		SpriteRenderer spriteRenderer;
		Animator animator;

        private Level level;
        private Counter hungerCounter;
        private Counter sleepCounter;
        private Counter coinsCounter;

        [SerializeField]
        private Stat sleep;
        [SerializeField]
        private Stat hunger;
        [SerializeField]
        private Stat coins;

        // Use this for initialization
        void Start () {
			spriteRenderer = GetComponent<SpriteRenderer> ();
			animator = GetComponent<Animator> ();

			level = LevelManager.Instance.Level;

            // get reference to "Counter" (Resources > GameConfiguration)
            hungerCounter = level.GetCounter("Hunger");
            sleepCounter = level.GetCounter("SleepDeprivation");
            coinsCounter = level.GetCounter("Coins");

            // create two instances of Stat Object
            sleep.Initialize(sleepCounter.GetInt(), sleepCounter.Configuration.IntMaximum, "sleep");
            hunger.Initialize(hungerCounter.GetInt(), hungerCounter.Configuration.IntMaximum, "hunger");
            coins.Initialize(coinsCounter.GetInt(), coinsCounter.Configuration.IntMaximum, "coins");
        }

		// Update is called once per frame
		void Update () {
			sleep.current_value = sleepCounter.GetInt ();
			hunger.current_value = hungerCounter.GetInt ();
            coins.current_value = coinsCounter.GetInt();
        }

		public void TrainPlayer(int hours){
			print (hours);
			// Sync slider and number
			// numHours.text = slider.value.ToString();
		}

		public void increasePhysique(float f){
			physique += f;
			print ("New physique is" + physique.ToString ());

			if (physique > 10) {
				print ("SWAG UNLOCKED");
				// Change Animator
				//AnimatorOverrideController overrideController = new AnimatorOverrideController (animator.runtimeAnimatorController);
				//animator.runtimeAnimatorController = overrideController;
				RuntimeAnimatorController swagController = (RuntimeAnimatorController)Resources.Load ("Sprites/swag/PlayerSwagWalk");
				animator.runtimeAnimatorController = swagController;
				//overrideController.runtimeAnimatorController = swagController;

				// change sprite renderer (static image)
				Sprite[] sprites = Resources.LoadAll<Sprite> ("Sprites/swag/player2");
				spriteRenderer.sprite = sprites [14];
			}
		}

		//	void OnTriggerEnter2D(Collider2D triggerCollider){
		//		print (triggerCollider.tag);
		//		GameLoop.increaseHealth (20);
		//
		//		showDialogBox ();
		//	}
		//
		//	void showDialogBox(){
		//		DialogManager.Instance.Show (title: "Hello World",
		//			text: "Some sample text here",
		//			doneCallback: DoneCallback,
		//			dialogButtons: DialogInstance.DialogButtonsType.OkCancel
		//		);
		//	}
		//
		//	public virtual void DoneCallback(DialogInstance dialogInstance){
		//        if (dialogInstance.DialogResult == DialogInstance.DialogResultType.Ok)
		//            DialogManager.Instance.ShowInfo("Ok Pressed");
		//        else
		//            DialogManager.Instance.ShowInfo("Cancel Pressed");
		//    }

	}

}