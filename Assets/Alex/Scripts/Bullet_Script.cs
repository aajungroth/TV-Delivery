using UnityEngine;
using System.Collections;

//Maintains bullet info (AAJ)
public class Bullet_Script : MonoBehaviour {

    //The bullets damage (AAJ)
    public int bulletDamage = -1;

    //The time since the bullet spawned (AAJ)
    public float bulletTimer = 0;

    //The time until the bullet disappears (AAJ)
    public float bulletDecayTime = 2.5f;

    //Initial time when bullet is spawned (AAJ)
    public float bulletSpawnTime = 0;

	// Use this for initialization
	void Start ()
    {
        //Gets the time when the bullet spawned (AAJ)
        bulletSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        //Advances the timer (AAJ)
        bulletTimer = Time.time;

        //Checks to see if the bullet has reached the decay time (AAJ)
        if(bulletTimer >= bulletDecayTime + bulletSpawnTime)
        {
            //Destroys the bullet (AAJ)
            Destroy(this.gameObject);
        }//if
        
	}

    //When the bullet hits an object (AAJ)
    void OnCollisionEnter2D(Collision2D collider)
    {
        //Does not stop the bullet if it hits the player as it is fired (AAJ)
        if (collider.gameObject.tag != "Player")
        {
            //Stops applying force to the bullet (AAJ)
            this.GetComponent<ConstantForce2D>().force = Vector2.zero;
            Destroy(this.gameObject);
        }//if
    }//OnTriggerEnter()
}
