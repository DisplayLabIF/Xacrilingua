using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModoAventura : MonoBehaviour {

	public GameObject estrela01;
	public GameObject estrela02;
	public GameObject estrela03;
	public GameObject estrela_escura01;
	public GameObject estrela_escura02;
	public GameObject estrela_escura03;
	public GameObject seta01;
	public GameObject seta02;
	public GameObject seta03;
	public GameObject cadeado01;
	public GameObject cadeado02;
	public GameObject cadeado03;
	public GameObject mensagemFinal;
	public Button fase01;
	public Button fase02;
	public Button fase03;
	public int tema01Completo;
	public int tema02Completo;
	public int tema03Completo;
	public int aventura01;
	public int aventura02;
	public int aventura03;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;

		aventura01 = PlayerPrefs.GetInt ("aventura01");
		aventura02 = PlayerPrefs.GetInt ("aventura02");
		aventura03 = PlayerPrefs.GetInt ("aventura03");

		estrela01.SetActive (false);
		estrela02.SetActive (false);
		estrela03.SetActive (false);
		estrela_escura01.SetActive (true);
		estrela_escura02.SetActive (true);
		estrela_escura03.SetActive (true);
		seta01.SetActive (false);
		seta02.SetActive (false);
		seta03.SetActive (false);
		fase01.interactable = false;
		fase02.interactable = false;
		fase03.interactable = false;
		mensagemFinal.SetActive (false);

		tema01Completo = PlayerPrefs.GetInt ("tema1");
		tema02Completo = PlayerPrefs.GetInt ("tema2");
		tema03Completo = PlayerPrefs.GetInt ("tema3");

		if (tema01Completo == 1) {
			estrela01.SetActive (true);
			seta01.SetActive (true);
			fase01.interactable = true;
			cadeado01.SetActive (false);
		}
		if ((tema02Completo == 1)&&(aventura01 == 1)) {
			seta01.SetActive (false);
			estrela02.SetActive (true);
			seta02.SetActive (true);
			fase02.interactable = true;
			cadeado02.SetActive (false);
		}
		if ((tema03Completo == 1)&&(aventura02 == 1)) {
			seta02.SetActive (false);
			estrela03.SetActive (true);
			seta03.SetActive (true);
			fase03.interactable = true;
			cadeado03.SetActive (false);
		}



		if (((aventura01 == 1) && (aventura02 == 1) && (aventura03 == 1))) {
			seta01.SetActive (false);
			seta02.SetActive (false);
			seta03.SetActive (false);
			mensagemFinal.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {		
	}

	public void voltarMenu(){
		SceneManager.LoadScene ("LoadScreenInicial");
	}

	public void carregarAventura01(){
		SceneManager.LoadScene ("LoadScreenAventura01");
	}

	public void carregarAventura02(){
		SceneManager.LoadScene ("LoadScreenAventura02");
	}

	public void carregarAventura03(){
		SceneManager.LoadScene ("LoadScreenAventura03");
	}

	public void VerificarTemaCompleto ()
	{
		

	}
}
