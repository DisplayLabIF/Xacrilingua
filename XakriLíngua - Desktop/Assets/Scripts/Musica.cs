using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour {

	public AudioSource somDaCamera;
	// Use this for initialization
	void Start () {
		somDaCamera.volume = PlayerPrefs.GetFloat ("volumeMusic");
	}

	// Update is called once per frame
	void Update () {
		somDaCamera.volume = PlayerPrefs.GetFloat ("volumeMusic");
	}
}
