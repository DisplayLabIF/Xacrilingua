using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBat : MonoBehaviour {
	public GameObject morcego;

	// Use this for initialization
	void Start () {
		morcego.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D outro)
	{
		if (outro.gameObject.tag == "Player") {
			morcego.SetActive (true);
		}
	}

}
