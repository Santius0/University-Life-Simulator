using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeSimulator
{
    public class IllnessEvent : GameEvent
    {

        // Use this for initialization
        public override void Start()
        {
            Debug.Log("due to the fact that life sucks.. you are sick");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}