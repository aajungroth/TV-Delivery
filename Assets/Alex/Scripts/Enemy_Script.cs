using UnityEngine;
using System.Collections;

public class Enemy_Script : MonoBehaviour {

    //Holds whether or not the enemy has been hit (AAJ)
    public bool isHit = false;

    //The time since the enemy was hit (AAJ)
    public float decayTimer = 0;

    //The time until the enemy decays (AAJ)
    public float enemyDecayTime = 3;

    //Initial time when the gun was fired (AAJ)
    public float hitTime = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //If the enemy has been hit begin decaying the enemy (AAJ)
        if(isHit == true)
        {
            //Advances the timer (AAJ)
            decayTimer = Time.time;

            //Checks to see if the bullet has reached the decay time (AAJ)
            if (decayTimer >= enemyDecayTime + hitTime)
            {
                //Destroys the enemy (AAJ)
                Destroy(this.gameObject);
            }//if
        }//if
    }

    //When a bullet hits an enemy (AAJ)
    void OnCollisionEnter2D(Collision2D collider)
    {
        //Only marks the enemy as hit if it collides with a bullet (AAJ)
        if((collider.gameObject.tag == "Bullet") || (collider.gameObject.tag == "Player"))
        {
            //Increases the enemies gravity (AAJ)
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;

            //Disables the enemies collider (AAJ)
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //Marks the enemy as hit (AAJ)
            isHit = true;

            //Sets the time that the enemy was hit (AAJ)
            hitTime = Time.time;
        }//if
    }//OnTriggerEnter()
}
