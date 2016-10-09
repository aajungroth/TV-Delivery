using UnityEngine;
using System.Collections;

public class DestroyedObjBehavior : MonoBehaviour {

    public float timeSpawn = 0;
    public float timer = 0;
    public float timeDie = 4.0f;
    bool done = false;
    // Use this for initialization
    void Start () {
        timeSpawn = Time.time;
        timeDie = timeSpawn + 4;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        timer = Time.time;
	    if(done == false)
        {
            if(timer > timeSpawn + 0.2f)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                done = true;
            } 
        }

        if (timer >= timeDie)
        {
            Destroy(this.gameObject);
        }
          
	}
}
