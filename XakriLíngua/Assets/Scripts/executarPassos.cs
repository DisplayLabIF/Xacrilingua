using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executarPassos : MonoBehaviour {

	public AudioSource somPassos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Passos ()
	{
		somPassos.Play();
	}
}
