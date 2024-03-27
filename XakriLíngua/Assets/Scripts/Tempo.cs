using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Tempo : MonoBehaviour {

	public int tempoRestante = 3;
	public int tempoDelay = 3;
	public Text txtTempo;
	public AudioClip fim;
	// Use this for initialization
	void Start () {
		StartCoroutine ("TempoPerdido");

	}
	
	// Update is called once per frame
	void Update () {		
		if (tempoRestante == 0) {
			StopCoroutine ("TempoPerdido");
			StartCoroutine ("TempoDelay");
			txtTempo.text = "FIM!";
			TocarSom (true);
		}
		if (tempoDelay <= 0) {
			StopCoroutine ("TempoDelay");
		}
	
	}
	IEnumerator TempoPerdido(){
		while (true) {
			yield return new WaitForSeconds (1);
			txtTempo.text = (tempoRestante.ToString ());
			tempoRestante--;
		}
	}

	IEnumerator TempoDelay(){
		while (true) {
			yield return new WaitForSeconds(1);
			tempoDelay--;
			SceneManager.LoadScene ("LoadScreenReprovado");
		}
	}
	void TocarSom(bool som){ // método requerindo uma variavel booleana
		if(som){
			// tocar som verdadeiro
			gameObject.GetComponent<AudioSource>().PlayOneShot(fim); // manda tocar 1 vez o audio de acerto
		}
	}
	public void voltarInicio(){
		SceneManager.LoadScene ("titulo");
	}
}
