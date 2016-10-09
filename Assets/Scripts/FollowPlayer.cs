using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private PlayerChar player;
    private Vector3 offset; 

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerChar>();
        offset = new Vector3(5, 2.8f, -10);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);

	}
}
