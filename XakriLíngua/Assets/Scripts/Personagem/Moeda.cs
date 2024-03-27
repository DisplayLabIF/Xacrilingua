using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moeda : MonoBehaviour {

	public Transform posicao;
	public float posicaoRange;
	public LayerMask whatIsPlayer;
	public GameObject moeda;
	public AudioClip moedaSom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] playerToCollect = Physics2D.OverlapCircleAll (posicao.position, posicaoRange, whatIsPlayer);
		for (int i = 0; i < playerToCollect.Length; i++) {
			playerToCollect [i].GetComponent <PlayerAtack> ().coins ++;
			//playerToCollect [i].GetComponent <Aventura03> ().coins ++;
			playerToCollect[i].GetComponent<AudioSource> ().PlayOneShot (moedaSom);
			moeda.SetActive (false);
		}	
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (posicao.position, posicaoRange);
	}
}
