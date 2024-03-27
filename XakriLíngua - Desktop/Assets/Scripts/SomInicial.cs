using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomInicial : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat ("volumeMusic", 0.5f);
		PlayerPrefs.SetFloat ("volumeSFX", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
