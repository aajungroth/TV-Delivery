using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    public float num;
    private Animator anim;

    // Use this for initialization
    void Start () {
        num = 0;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("n", num);
	}

    void add()
    {
        num += 0.5f;
        if(num > 26)
        {
            num = 0;
        }
    }
}
