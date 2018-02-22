using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            save();
        else if (Input.GetKeyDown(KeyCode.L))
            load();
        else if (Input.GetKeyDown(KeyCode.X))
            reset();

    }

    void save()
    {
        GameController.game.player_position_x = transform.position.x;
        GameController.game.player_position_y = transform.position.y;
        GameController.game.Save();
    }

    void load()
    {
        GameController.game.Load();
        transform.position = new Vector2(GameController.game.player_position_x, GameController.game.player_position_y);
    }

    void reset()
    {
        GameController.game.Delete();
    }
}
