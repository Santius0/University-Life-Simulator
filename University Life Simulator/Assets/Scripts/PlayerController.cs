using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CnControls;

public class PlayerController : MonoBehaviour {

	public float speed = 3f;

	Vector2 velocity;
	Rigidbody2D rigidbody;
	Animator animator;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input;
		if (Input.GetAxisRaw ("Horizontal") == 1 || Input.GetAxisRaw ("Vertical") == 1) {
			// Keyboard input
			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		} else {
			// Virtual Joystick input
			input = new Vector2 (CnInputManager.GetAxisRaw ("Horizontal"), CnInputManager.GetAxisRaw ("Vertical"));
		}

		input = RemoveDiagonalMovement (input);

		Vector2 direction = input.normalized;
		AnimateMovement(direction);

		velocity = direction * speed;
	}

	void FixedUpdate(){
		rigidbody.position += velocity * Time.fixedDeltaTime;
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
