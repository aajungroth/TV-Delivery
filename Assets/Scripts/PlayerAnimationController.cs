using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

    public bool isJumping;
    public bool isDucking;
    private Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(anim != null)
        {
            anim.SetBool("isDucking", isDucking);
            anim.SetBool("isJumping", isJumping);

        }

     
    }
}
