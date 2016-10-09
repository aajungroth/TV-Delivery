using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	public float energyLevel = 30;


	// Use this for initialization
	void Start () {

		transform.localScale = new Vector3(3, energyLevel, -1);
		transform.position = new Vector3 (0, (float)(energyLevel / 20.0), 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
