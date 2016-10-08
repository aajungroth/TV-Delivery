using UnityEngine;
using System.Collections;

public class PlayerChar : MonoBehaviour {

    
    public int power = 100;

    //Vector2 movement = new Vector2(0, 0);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (power <= 0)
        {

            print("game over");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ObjectHurts")
        {
            print("collided");
            power -= 10;
            print(power);

        }
    }
}
