using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameFramework.GameStructure.Levels;
using GameFramework.GameStructure.GameItems.ObjectModel;

namespace LifeSimulator {
	
	public struct EventInstance 
	{
		public int time;
		public bool hasExecuted;
		public GameEvent gameEvent;
	}

	public class EventManager : MonoBehaviour {
		private Counter timeCounter;
		private int time;

		Queue eventQueue = new Queue();
		EventInstance nextEvent;


		// Use this for initialization
		void Start () {
			timeCounter = LevelManager.Instance.Level.GetCounter ("Time");

			EventInstance ae = new EventInstance{ time = 100, hasExecuted=false, gameEvent = new AssaultEvent () };
			eventQueue.Enqueue (ae);

            EventInstance measles = new EventInstance { time = 250, hasExecuted = false, gameEvent = new IllnessEvent() };
            eventQueue.Enqueue(measles);

			nextEvent = (EventInstance)eventQueue.Dequeue ();
		}
		
		// Update is called once per frame
		void Update () {
			time = (int)timeCounter.GetInt ();

            if (!nextEvent.Equals(null))
            {
                if (time >= nextEvent.time && !nextEvent.hasExecuted)
                {
                    nextEvent.hasExecuted = true;
                    print("SQUAAAAAAAAAAAAAA");
                    nextEvent.gameEvent.Start();

                    if (eventQueue.Count > 0)
                        nextEvent = (EventInstance)eventQueue.Dequeue();
                }
            }
		}
	}
}
