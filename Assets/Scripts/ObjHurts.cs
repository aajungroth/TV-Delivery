using UnityEngine;
using System.Collections;

public class ObjHurts : MonoBehaviour {

    public GameObject destroyedObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("collided with player");
          if(destroyedObj != null)
            Instantiate(destroyedObj, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
