using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDrop : MonoBehaviour {

	// Use this for initialization
	public AudioClip drop;
	void Start () {
		gameObject.GetComponent<AudioSource> ().PlayOneShot (drop);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
