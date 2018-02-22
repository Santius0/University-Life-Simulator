using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class PlayerController2 : AbstractCharacter
{
    [SerializeField]
    private Stat sleep;
    [SerializeField]
    private float start_sleep_value;
    [SerializeField]
    private float max_sleep_value;
    [SerializeField]
    private Stat hunger;
    [SerializeField]
    private float start_hunger_value;
    [SerializeField]
    private float max_hunger_value;
    private float game_time;

    // Use this for initialization
    protected override void Start () {
        sleep.Initialize(start_sleep_value, max_sleep_value, "sleep");
        hunger.Initialize(start_hunger_value, max_hunger_value, "hunger");
    }
	
    private void GetInput()
    {
        Vector2 input;
        //if using keyboard
        // if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == 1)
        // {
        //TODO: Only keyboard functioniality for now. Add Joystick and click to move later
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // }
        if (Mathf.Abs(input.y) >= Mathf.Abs(input.x))
        {
            input.x = 0;
        }
        else
        {
            input.y = 0;
        }
            end_val = input.normalized * walkspeed * Time.fixedDeltaTime; ;
    }

	// Update is called once per frame
    //Gets input then uses abstract class to update position
	protected override void Update () {
        if (Time.timeScale > 0)
        {
            //game_time = Time.realtimeSinceStartup;
            //Debug.Log(game_time);
            GetInput();
            base.Update();
        }
	}
}
