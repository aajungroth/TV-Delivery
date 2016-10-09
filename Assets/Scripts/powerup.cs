using UnityEngine;
using System.Collections;

public class powerup : MonoBehaviour
{

    public float energy = 10;
    public bool destructible = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().energyLevel += energy;
            if (destructible)
                Destroy(this.gameObject);
            else
                this.enabled = false;
        }
    }
}
