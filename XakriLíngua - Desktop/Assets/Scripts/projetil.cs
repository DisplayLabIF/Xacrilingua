using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour {

	public float speed;
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {

		rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D outro)
	{
		if (outro.gameObject.CompareTag ("parede") | (outro.gameObject.CompareTag ("chao")) | (outro.gameObject.CompareTag ("fantasma")| (outro.gameObject.CompareTag ("agua")))) {
			Destroy (gameObject);
		}
	}

}
