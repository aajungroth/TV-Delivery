using UnityEngine;
using System.Collections;

//Fires the players gun and spawns bullets (AAJ)
public class Shooting_Script : MonoBehaviour {

    //The bullet the gun fires (AAJ)
    public GameObject bullet;

    //The time since the gun fired (AAJ)
    public float reloadTimer = 0.5f;

    //The time until the gun reloads (AAJ)
    public float reloadWaitTime = 0.5f;

    //Initial time when the gun was fired (AAJ)
    public float firedTime = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Checks to see if the gun has reloaded (AAJ)
        if (reloadTimer >= reloadWaitTime + firedTime)
        {
            //Shoots the gun (AAJ)
            Shoot();
        }//if
        else
        {
            //Advances the timer (AAJ)
            reloadTimer = Time.time;
        }//else
    }

    //Shoots the gun (AAJ)
    void Shoot()
    {
        //Fires the gun when the space bar is released (AAJ)
        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            //Creates a new bullet (AAJ)
            Instantiate(bullet, transform.position, Quaternion.identity);

            //Records when the gun was fired (AAJ)
            firedTime = Time.time;

            //Resets the reloadTimer (AAJ)
            reloadTimer = 0;
        }//if
    }//Shoot
}
