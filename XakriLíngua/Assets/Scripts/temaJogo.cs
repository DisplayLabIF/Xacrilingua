using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temaJogo : MonoBehaviour {

	public Button btnPlay;
	public Button btnAventura;
	public Text txtNomeTema;	
	public Text txtInfoTema;
	public GameObject infoTema;
	public GameObject estrela1;
	public GameObject estrela2;
	public GameObject estrela3;
	public GameObject msgAventura01;
	public GameObject msgAventura02;
	public GameObject msgAventura03;
	public GameObject cadeado02;
	public GameObject cadeado03;
	public int tema01Completo;
	public int tema02Completo;
	public int tema03Completo;
	public Button btnTema02;
	public Button btnTema03;
	public int tema1;
	public int tema2;
	public int tema3;

	public int notaFinal;
	public bool verificadorTemas;



	public string[] nomeTema;
	private int idTema ;
	public int numeroQuestoes;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		txtNomeTema.text = nomeTema [idTema];
		txtInfoTema.text = "Selecione um Tema!";
		infoTema.SetActive (true);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		btnPlay.interactable = false;

	}
		
	void Update ()
	{
		mensagemAventura ();
		tema01Completo = PlayerPrefs.GetInt ("tema1");
		tema02Completo = PlayerPrefs.GetInt ("tema2");
		tema03Completo = PlayerPrefs.GetInt ("tema3");

		if (tema01Completo == 1) {
			btnTema02.interactable = true;
			cadeado02.SetActive (false);
		} else {
			btnTema02.interactable = false;
			cadeado02.SetActive (true);
		}
		if (tema02Completo == 1) {
			btnTema03.interactable = true;
			cadeado03.SetActive (false);
		} else {
			btnTema03.interactable = false;
			cadeado03.SetActive (true);
		}	
	}

	public void selecioneTema (int i)
	{
		idTema = i;
		if ((idTema == 1) && (tema1 == 1)) {
			msgAventura01.SetActive (true);
		} else {
			msgAventura01.SetActive (false);
		}

		if ((idTema == 2)&&(tema2 == 1)) {
			msgAventura02.SetActive (true);
		}else {
			msgAventura02.SetActive (false);
		}

		if ((idTema == 3)&&(tema3 == 1)) {
			msgAventura03.SetActive (true);
		}else {
			msgAventura03.SetActive (false);
		}

		PlayerPrefs.SetInt ("idTema", idTema);
		txtNomeTema.text = nomeTema [idTema];
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		int notaFinal = PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ());
		int acertos = PlayerPrefs.GetInt ("acertos" + idTema.ToString ());
		if (notaFinal == 10) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);
		} else if (notaFinal >= 6) {
			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);

		} else if (notaFinal >= 5) {
			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}
		txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+numeroQuestoes.ToString()+" questões";
		infoTema.SetActive(true);
		btnPlay.interactable = true;
	}
		

	public void jogar(){
		SceneManager.LoadScene ("LoadScreenT" + idTema.ToString());
	}

	public void mensagemAventura ()
	{
		if (tema1 == 1) {
			this.tema1 = 1;
			PlayerPrefs.SetInt ("tema1", tema1);

		}
		if (tema2 == 1) {
			this.tema2 = 1;
			PlayerPrefs.SetInt ("tema2", tema2);
		}
		if (tema3 == 1) {
			this.tema3 = 1;
			PlayerPrefs.SetInt ("tema3", tema3);
		}

	}

}
