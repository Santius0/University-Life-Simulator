using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;
using GameFramework.UI.Dialogs.Components;

public class AiController : MonoBehaviour {
	public float speed = 3f;

	Vector2 velocity;
	Rigidbody2D rigidbody;
	Animator animator;

	private Transform target;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		target = GameObject.Find ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
//		Vector2 input;
//		if (Input.GetAxisRaw ("Horizontal") == 1 || Input.GetAxisRaw ("Vertical") == 1) {
//			// Keyboard input
//			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
//		} else {
//			// Virtual Joystick input
//			input = new Vector2 (CnInputManager.GetAxisRaw ("Horizontal"), CnInputManager.GetAxisRaw ("Vertical"));
//		}
//
//		input = RemoveDiagonalMovement (input);
//
//		Vector2 direction = input.normalized;
//		AnimateMovement(direction);
//
//		velocity = direction * speed;
		MoveEnemy();
	}

	void FixedUpdate(){
		rigidbody.position += velocity * Time.fixedDeltaTime;
	}

    public void MoveEnemy()
    {
        //Declare variables for X and Y axis move directions, these range from -1 to 1.
        //These values allow us to choose between the cardinal directions: up, down, left and right.
        int xDir = 0;
        int yDir = 0;

		float xDiff = Mathf.Abs (target.position.x - transform.position.x);
		float yDiff = Mathf.Abs (target.position.y - transform.position.y);
		float pythagorean_distance = Mathf.Sqrt ((xDiff * xDiff) + (yDiff * yDiff));
		print (pythagorean_distance);

		if (pythagorean_distance > 0.8) {
			// walk to meet player, cover the widest plane first
			if(xDiff > 0.1)
				// move player left or right
				xDir = target.position.x > transform.position.x ? 1 : -1;
			else
				// move player up or down
				yDir = target.position.y > transform.position.y ? 1 : -1;

		} else {
			// kill player
			print ("LASH");
			DialogManager.Instance.ShowInfo ("Stabbed to death... game over");
		}

        //Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
        //AttemptMove<Player>(xDir, yDir);
		Vector2 direction = new Vector2(xDir, yDir);
		print (direction.ToString ());
		AnimateMovement(direction);
		velocity = direction * speed;
    }
		

    Vector2 RemoveDiagonalMovement (Vector2 input){
		if (Mathf.Abs (input.y) >= Mathf.Abs (input.x)) {
			input.x = 0;
		} else {
			input.y = 0;
		}
		return input;
	}

	void AnimateMovement(Vector2 direction){
		// Using new Animator
		if (direction.x == 0 && direction.y == 0) {
			animator.enabled = false;
		} else if (Mathf.Abs (direction.y) >= Mathf.Abs (direction.x)) {
			// For Dpad with float directions, calculate primary direction
			// Primary direction is Vertical
			if (direction.y > 0) {
				animator.enabled = true;
				animator.Play ("PlayerWalkUp");
			} else if (direction.y < 0) {
				animator.enabled = true;
				animator.Play ("PlayerWalkDown");
			}
		} else {
			// Primary direction is Horizontal
			if (direction.x > 0) {
				animator.enabled = true;
				animator.Play ("PlayerWalkRight");
			} else if (direction.x < 0) {
				animator.enabled = true;
				animator.Play ("PlayerWalkLeft");
			}
		}
	}

}
