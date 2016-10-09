using UnityEngine;
using System.Collections;

public class playerinvincible : MonoBehaviour {

    private PlayerChar player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerChar>();
	}
	
	// Update is called once per frame
	void Update () {


    }

    void OnCollisionEnter2D(Collision2D other )
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.invincible = true;
        }
    }
}
