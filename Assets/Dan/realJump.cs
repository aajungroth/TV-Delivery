using UnityEngine;
using System.Collections;

public class realJump : MonoBehaviour {

    // Use this for initialization
    Vector2 movementDirection = Vector2.up;
    public float forceMultiplier = 10;

    public float count = 0;
    Rigidbody2D Player;
    bool isJumping = true;
    // Use this for initialization
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {     
           if (isJumping)
            {
                Player.velocity = new Vector2(Player.velocity.x, 0);
            Player.velocity = Player.velocity + movementDirection * forceMultiplier;
           // print("hit space");
          //  print(count);
            //count += 1;

              //  bounce = false;
            }
            //bounce = true;
        }
    }
}
