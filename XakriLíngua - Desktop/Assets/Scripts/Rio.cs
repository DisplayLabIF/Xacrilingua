using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rio : MonoBehaviour {
	public AudioClip agua;
	public GameObject player;

	public int verificador01;
	public int verificador02;
	public int verificador03;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D outro)
	{
		if(outro.gameObject.CompareTag("Player")){
			gameObject.GetComponent<AudioSource> ().PlayOneShot (agua);
			Destroy (player,0.6f);
			StartCoroutine (Pausa ());
		}
	}

	IEnumerator Pausa ()
	{
		yield return new WaitForSeconds (3);
		if (verificador01 == 1) {
			SceneManager.LoadScene ("LoadScreenAventura01");
		}
		if (verificador02 == 1) {
			SceneManager.LoadScene ("LoadScreenAventura02");
		}
		if (verificador03 == 1) {
			SceneManager.LoadScene ("LoadScreenAventura03");
		}

	}
}
