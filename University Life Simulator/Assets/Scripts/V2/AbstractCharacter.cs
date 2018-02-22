using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We make CharacterController abstract so we can use it for both plyer and any potential NPS etc
public abstract class AbstractCharacter : MonoBehaviour
{

    [SerializeField]
    protected float walkspeed;
    Rigidbody2D rbody;
    protected Vector2 end_val;

    // Use thi s for initialization
    protected virtual void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(Time.timeScale > 0)
        //Moves sprite to end postion vis a translate tranforamtion..no animation added yet
            Move(end_val);
    }

    //Adjusts rigid body using fixed update for approprite collsion
    private void FixedUpdate()
    {
        rbody.position += end_val;
    }

    public void Move(Vector2 end)
    {
        transform.Translate(end);
    }
}
