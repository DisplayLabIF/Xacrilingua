using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

	// Use this for initialization
	public GameObject morcego1;
	public GameObject morcego2;
	public GameObject morcego3;
	public GameObject morcego4;
	public GameObject morcego5;
	public GameObject morcego6;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D outro)
	{
		if (outro.gameObject.tag == "Player") {
			Destroy (morcego1);
			Destroy (morcego2);
			Destroy (morcego3);
			Destroy (morcego4);
			Destroy (morcego5);
			Destroy (morcego6);

		}
	}
}
