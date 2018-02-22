using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameFramework.GameObjects;

namespace LifeSimulator
{
    public class Assault : MonoBehaviour
    {
        private GameObject _player;
        BasePlayer assaulter;

        // Use this for initialization
        void Start()
        {
            _player = GameObject.Find("Player");

            // create instance of assaulter
            BasePlayer assaulter = Instantiate(Resources.Load("Sprites/assaulter/assaulter", typeof(BasePlayer))) as BasePlayer;
            assaulter.test();
        }

        // Update is called once per frame
        void Update()
        {
            // calculate distance between player and assaulter
            // print(_player.ToString());

        }
    }
}
