using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 movementVector, moveVec, gravity;
    private bool isJumping = false;
    private bool secondJump = false;
    private float JumpCD = 0.2f;
    private bool isDucking;

    private PlayerAnimationController pAnim;

    private float energyLevel; //min = 0, max = 100

    private BoxCollider2D[] col = new BoxCollider2D[2];
    private BoxCollider2D topBox, botBox;
    private float collOffset;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector2(2f, 0);
        //movementVector.y *= 5; //gravity
        moveVec = new Vector2(0, 0);
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;

        energyLevel = 0;

        pAnim = GetComponent<PlayerAnimationController>();

        col = GetComponents<BoxCollider2D>();
        if(col[0].size.x > col[1].size.x)
        {
            topBox = col[0];
            botBox = col[1];
        }
        else
        {
            topBox = col[1];
            botBox = col[0];
        }
        collOffset = botBox.offset.y;
	}
	
	// Update is called once per frame
	void Update () {
        moveVec.x = movementVector.x * energyLevel / 5.0f;

        pAnim.isJumping = isJumping;
        pAnim.isDucking = isDucking;


        if (energyLevel < 0)
            energyLevel = 0;

        energyLevel += Time.deltaTime * 12;

        if (energyLevel > 100)
        {
            //Time.timeScale = 0;
           // Destroy(this.gameObject);
            //end game
        }

        Move();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (isJumping)
        {
            JumpCD -= Time.unscaledDeltaTime;
        }

        if (!isJumping)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                isDucking = true;
                if (topBox.enabled)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + 2 * collOffset);
                    topBox.enabled = false;
                    botBox.offset = new Vector2(botBox.offset.x, 0);
                }
            }
            else
            {
                isDucking = false;
                if (!topBox.enabled)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - 2 * collOffset);
                    topBox.enabled = true;
                    botBox.offset = new Vector2(botBox.offset.x, collOffset);
                }
            }
        }

        //jumping is pretty bad, and someone else is working on it
        //based on energy bar
        /*Move(movementVector);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (isJumping)
            JumpCD -= Time.unscaledDeltaTime; 
            */
    }

    void Move()
    {
        // movementVector.y -= .05f * Time.unscaledDeltaTime;
        //Debug.Log(moveVec.x + " " + energyLevel);
        //rb.velocity = moveVec;
    }

    void Jump()
    {
        isDucking = false;
        if (!isJumping || !secondJump)
        {
            if (isJumping)
            {
                if (JumpCD < 0)
                {
                    //moveVec.y = 10f * Time.unscaledDeltaTime;
                    secondJump = true;
                }
            }
            else
            {
                //moveVec.y += 10f * Time.unscaledDeltaTime;
                isJumping = true;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            secondJump = false;
            JumpCD = 0.2f;
            movementVector.y = 0;
        }
    }
}
