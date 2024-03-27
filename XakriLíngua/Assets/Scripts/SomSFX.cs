using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomSFX : MonoBehaviour {
	public AudioSource somSFX;
	// Use this for initialization
	void Start () {
		somSFX.volume = PlayerPrefs.GetFloat ("volumeSFX");
	}

	// Update is called once per frame
	void Update () {
		somSFX.volume = PlayerPrefs.GetFloat ("volumeSFX");
	}
}
