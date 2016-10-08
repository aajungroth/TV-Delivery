using UnityEngine;
using System.Collections;

public class Flying_Enemy_Script : MonoBehaviour {

    //If the flying enemy is hit (AAJ)
    public bool isHit = false;
    
    //The direction of the flying enemy is either up or down
    public bool isUp = true;

    //The force that mvoes the enemy up and down
    public float flightUpForce = 15;

    //The force that mvoes the enemy up and down
    public float flightDownForce = 0;

    //The time since the flying enemy switched direction (AAJ)
    public float switchTimer = 1;

    //The time until the flying enemy swithes direction (AAJ)
    public float switchWaitTime = 3;

    //Initial time when the enemy switched (AAJ)
    public float lastSwitchTime = 0;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isHit == false)
        {
            //Advances the timer (AAJ)
            switchTimer = Time.time;

            //Checks to see if the bullet has reached the decay time (AAJ)
            if(switchTimer >= switchWaitTime + lastSwitchTime)
            {
                //Switches the direction of the flying enemy (AAJ)
                switchDirection();

                //Resets the timer (AAJ)
                switchTimer = 0;
                lastSwitchTime = Time.time;
            }//if
        }//if
    }

    // Switches the direction the flying enemy moves in (AAJ)
    void switchDirection()
    {
        //Saves the flying enemies force in a temporary vector (AAJ)
        Vector2 tempVector = this.gameObject.GetComponent<ConstantForce2D>().relativeForce;

        if(isUp == true)
        {
            isUp = false;
            this.gameObject.GetComponent<ConstantForce2D>().relativeForce = new Vector2(tempVector.x, flightDownForce);
        }//if
        else if(isUp == false)
        {
            isUp = true;
            this.gameObject.GetComponent<ConstantForce2D>().relativeForce = new Vector2(tempVector.x, flightUpForce);
        }//else
    }

    //When a bullet hits an enemy (AAJ)
    void OnCollisionEnter2D(Collision2D collider)
    {
        //Saves the flying enemies force in a temporary vector (AAJ)
        Vector2 tempVector = this.gameObject.GetComponent<ConstantForce2D>().relativeForce;

        //Only marks the flying enemy as hit if it collides with a bullet (AAJ)
        if (collider.gameObject.tag == "Bullet")
        {
            //Marks the enemy as hit (AAJ)
            isHit = true;

            //Sets the force on the flying enemy to zero (AAJ)
            this.gameObject.GetComponent<ConstantForce2D>().relativeForce = new Vector2(tempVector.x, 0);
        }//if
    }//OnTriggerEnter()
}
