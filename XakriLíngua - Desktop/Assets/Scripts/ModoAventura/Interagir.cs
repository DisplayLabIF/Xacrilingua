using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interagir : MonoBehaviour {
	public Image botaoAcao;
	public Sprite qualAcao;
	public Sprite btnAcao;
	public Animator efeitoBotao;
	public GameObject efeito;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D outro)
	{
		if (outro.gameObject.tag == "Player") {
			botaoAcao.sprite = qualAcao;
			efeito.SetActive (true);
			efeitoBotao.SetBool ("efeito", true);
		}
	}
	void OnTriggerExit2D (Collider2D outro){
		if (outro.gameObject.tag == "Player") {
			botaoAcao.sprite = btnAcao;
			efeitoBotao.SetBool ("efeito", false);
			efeito.SetActive (false);
		}
	}
}
