using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	float energyLevel = 10;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(1, energyLevel, -1);
		transform.position = new Vector3 (0, (float)(energyLevel / 20.0), 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) {
			energyLevel = 10;
		} else if (transform.localScale.y > 0) {
			energyLevel -= 0.02F;
			transform.localScale = new Vector3 (1, energyLevel, 0);
			transform.position = new Vector3 (0, (float)(energyLevel / 20.0), 0);
		} else {
			print ("You're Dead");
		}

	}
}
