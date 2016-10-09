using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void play(){
		Application.LoadLevel("Scene1");
	}

	public void quit(){
		Application.Quit();
	}
}
