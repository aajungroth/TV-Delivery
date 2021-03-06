﻿using UnityEngine;
using System.Collections;

public class PlayerChar : MonoBehaviour
{
    private Rigidbody2D rb;

    public float energyLevel = 30;

    private bool isJumping = false;
    public bool isDucking = false;

    public bool invincible = false;
    public bool end = false;

    private PlayerAnimationController pAnim;
    private BoxCollider2D[] col = new BoxCollider2D[2];
    private BoxCollider2D topBox, botBox;
    private float collOffset;

    //The energy bar (AAJ)
    GameObject energyBar;

    //Vector2 movement = new Vector2(0, 0);
    // Use this for initialization
    void Start()
    {
        //Finds the energy bar (AAJ)
        rb = GetComponent<Rigidbody2D>();
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar");

        pAnim = GetComponent<PlayerAnimationController>();

        col = GetComponents<BoxCollider2D>();
        if (col[0].size.x > col[1].size.x)
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
    void Update()
    {
        if(end)
        {
            rb.velocity = new Vector2(3 + energyLevel / 3.0f, rb.velocity.y);

            rb.velocity = new Vector2(2 + energyLevel / 4.0f, rb.velocity.y);

            pAnim.isJumping = isJumping;
            pAnim.isDucking = isDucking;
        }

        if (energyBar.transform.localScale.y > 0)
        {
            isDucking = true;
            GetComponent<Animator>().SetBool("isDucking", true);
            GetComponent<Animator>().SetBool("isJumping", false);

            rb.velocity = Vector2.zero;
        }
        else if (invincible)
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(2 + energyLevel / 4.0f, rb.velocity.y);
            pAnim.isJumping = isJumping;
            pAnim.isDucking = isDucking;
            

            if (energyBar.transform.localScale.y > 0)
            {
                energyLevel -= 0.01F;
                energyBar.transform.localScale = new Vector3(3, energyLevel, 0);
                energyBar.transform.position = energyBar.transform.parent.transform.position + new Vector3(energyLevel / 20.0f - 1.5f, 0, 0);
            }
            else
            {
                if (!invincible)
                    Debug.Log("You're Dead");
            }

            energyBar.GetComponent<EnergyBar>().energyLevel = energyLevel;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }//if

            //ducking
            if(!isJumping)
            {
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    isDucking = true;
                    if (topBox.enabled)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y + 2 * collOffset);
                        topBox.enabled = false;
                        botBox.offset = new Vector2(botBox.offset.x, 0);
                    }//if
                }//if
                else
                {
                    isDucking = false;
                    if (!topBox.enabled)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y - 2 * collOffset);
                        topBox.enabled = true;
                        botBox.offset = new Vector2(botBox.offset.x, collOffset);
                    }//if
                }//else

                if (energyLevel > 30)
                {
                    energyLevel = 30;
                }//if
            }//if
        }//else
    }//Update

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ObjectHurts")
        {
            print("collided");
            energyLevel -= 2;

            //Updates the engery bar (AAJ)
            energyBar.GetComponent<EnergyBar>().energyLevel = energyLevel;
        }

        if (coll.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void Jump()
    {
        isDucking = false;
        if (!isJumping)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = rb.velocity + Vector2.up * 30;
        }
    }
}
