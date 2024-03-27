using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour {

	private float tempoEntreAtaque;
	public float startTempoEntreAtaque;
	public Transform firePoint;
	public GameObject projetil;
	public int quantidade;
	private int duplo = 1;

	// Update is called once per frame
	void Update ()
	{
		if (duplo > 0) {
			if (Input.GetKey (KeyCode.C)) {		
				Shoot ();
				duplo--;
				StartCoroutine (Pausa());
			}
		} 
	}

	void Shoot(){
		for(int i = 0; i < quantidade; i++){
				Instantiate (projetil, firePoint.position, firePoint.rotation);
		}
	}

	IEnumerator Pausa(){
		
		yield return new WaitForSeconds (1);
		duplo = 1;
	}

}
