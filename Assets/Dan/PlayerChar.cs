using UnityEngine;
using System.Collections;

public class PlayerChar : MonoBehaviour {

    
    public float energyLevel = 30;

    //The energy bar (AAJ)
    GameObject energyBar;

    //Vector2 movement = new Vector2(0, 0);
    // Use this for initialization
    void Start()
    {
        //Finds the energy bar (AAJ)
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            energyLevel -= 0.5F;
        }

        if (energyBar.transform.localScale.y > 0)
        {
            energyLevel -= 0.02F;
            energyBar.transform.localScale = new Vector3(3, energyLevel, 0);
            energyBar.transform.position = new Vector3(0, (float)(energyLevel / 20.0), 0);
        }
        else {
             Debug.Log("You're Dead");
        }

        energyBar.GetComponent<EnergyBar>().energyLevel = energyLevel;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ObjectHurts")
        {
            print("collided");
            energyLevel -= 10;

            //Updates the engery bar (AAJ)
            energyBar.GetComponent<EnergyBar>().energyLevel = energyLevel;
        }
    }
}
