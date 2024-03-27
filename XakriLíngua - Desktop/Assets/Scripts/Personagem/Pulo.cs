using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulo : MonoBehaviour {

	private int forca = 550;
	public Rigidbody2D personagem;
	public bool liberaPulo = false;
	public int duplo = 1;
	public Animator animador;
	public AudioClip agua;
	public AudioClip pulo;

	// Use this for initialization
	void Start () {
		animador.SetBool("noChao",true);
		animador.SetBool("seMovendo",false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//CONDICIONAL PARA LIBERAR APENAS UM PULO POR VEZ
		Pular();
	}

	//CONDICIONAL PARA ACIONAR NOVO PULO QUANDO TOCAR AO CHÃO


	public void pularAndroid (){
		if (duplo > 0) {
			personagem.AddForce (new Vector2 (0, forca), ForceMode2D.Impulse);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (pulo);
				
			duplo--;
			}
		}

	public void Pular ()
	{
		if (duplo > 0) {
			if (Input.GetKey (KeyCode.Space)) {
				personagem.AddForce (new Vector2 (0, forca), ForceMode2D.Impulse);
				duplo--;
			}
		}
	}

	
	void OnCollisionEnter2D (Collision2D outro)
	{
		if (outro.gameObject.CompareTag ("chao")) {
			duplo = 1;
			liberaPulo = true;
			animador.SetBool ("noChao", true);
		}
		if (outro.gameObject.CompareTag ("canoa")) {
			duplo = 1;
			liberaPulo = true;
			animador.SetBool ("noChao", true);
		}

		if (outro.gameObject.CompareTag ("agua")) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (agua);
		}

	}

	void OnCollisionExit2D (Collision2D outro)
	{
		if (outro.gameObject.CompareTag ("chao")) {
			liberaPulo = false;
			animador.SetBool ("noChao",false);
		}
		if (outro.gameObject.CompareTag ("canoa")) {
			liberaPulo = false;
			animador.SetBool ("noChao",false);
		}
	}
}


