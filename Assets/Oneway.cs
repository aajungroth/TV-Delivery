using UnityEngine;
using System.Collections;

public class Oneway : MonoBehaviour
{

    public BoxCollider2D box2;
    private PlayerChar player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerChar>();
        box2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y + 0.9f)
            box2.enabled = true;
        else if((player.transform.position.y < transform.position.y + 0.5f))
            box2.enabled = false;
    }


}
