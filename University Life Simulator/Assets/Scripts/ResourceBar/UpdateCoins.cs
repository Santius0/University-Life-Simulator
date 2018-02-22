using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameFramework.GameStructure;
using GameFramework.GameStructure.Levels;
using GameFramework.GameStructure.Levels.ObjectModel;
// using GameFramework.GameStructure.Players.ObjectModel;
using GameFramework.GameStructure.GameItems.ObjectModel;

public class UpdateCoins : MonoBehaviour {
	public Image coinImage;
	public Text coinText;

	// private Player player;
	private Level level;
	private Counter coinCounter;
	private float maxCoins;


	// Use this for initialization
	void Start () {
		// coinImage = GetComponent<Image> ();

		// player = GameManager.Instance.Player;
		level = LevelManager.Instance.Level;
		coinCounter = level.GetCounter("Coins");
	}
	
	// Update is called once per frame
	void Update () {
		coinImage.fillAmount = coinCounter.GetNormalisedAmount ();
		coinText.text = "$" + coinCounter.GetInt();
	}

}
