using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morcego : MonoBehaviour {

	// Use this for initialization
	public float velocidade;
	public float distanciaParada;
	private Transform target;

	void Start () {
		

		}
	
	// Update is called once per frame
	void Update ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		if (Vector2.Distance (transform.position, target.position) > distanciaParada) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, velocidade * Time.deltaTime);
		} else {
			target.GetComponent<PlayerAtack> ().health--;
			Destroy (gameObject);
		}
	}

}
