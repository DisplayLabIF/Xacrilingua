using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testeFinal : MonoBehaviour {

	public GameObject ResultadoFinal;
	public GameObject ResultadoReprovado;
	public GameObject TelaTesteFinal;
	public GameObject TelaTesteFinal02;
	public GameObject colisor;
	public GameObject efeitoCoruja;
	public GameObject GameController;
	private int checkTesteFinal;
	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;

	public string[] perguntas; //armazena todas as perguntas
	public string[] alternativaA; //armazena todas as alternativas A
	public string[] alternativaB; //armazena todas as alternativas B
	public string[] alternativaC; //armazena todas as alternativas C
	public string[] alternativaD; //armazena todas as alternativas D
	public string[] corretas; //armazena todas as alternativas corretas

	public int idPergunta;

	private float acertos;
	private float questoes;
	private float media;
	private int notaFinal;
	private int duplo = 1;
	public AudioClip quizFail;
	public AudioClip quizComplete;
	// Use this for initialization
	void Start () {
	 	duplo = 1; 
		idPergunta = 0;
		questoes = perguntas.Length;
		pergunta.text = perguntas[idPergunta];
		respostaA.text = alternativaA[idPergunta];
		respostaB.text = alternativaB[idPergunta];
		respostaC.text = alternativaC[idPergunta];
		respostaD.text = alternativaD[idPergunta];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resposta (string alternativa)
	{
		if (duplo > 0) {
			if (alternativa == "A") {
				if (alternativaA [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					duplo--;

				} 
			} else if (alternativa == "B") {
				if (alternativaB [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					duplo--;
				
				} 
			} else if (alternativa == "C") {
				if (alternativaC [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					duplo--;

				} 
			} else if (alternativa == "D") {
				if (alternativaD [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					duplo--;

				}
			}
			proximaPergunta ();

		}
	}

	public void proximaPergunta ()
	{
		
		duplo = 1;
		idPergunta += 1;
		StartCoroutine (Pausa ());
		if (idPergunta <= questoes - 1) {
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];
		}else {
			media = 10 * (acertos / questoes);
			notaFinal = Mathf.RoundToInt (media);
			Debug.LogError (media);
			if (notaFinal == 10) {
				TelaTesteFinal02.SetActive (false);
				ResultadoFinal.SetActive (true);
				checkTesteFinal = 1;
				efeitoCoruja.SetActive (false);
				gameObject.GetComponent<AudioSource> ().PlayOneShot (quizComplete);
				Destroy (colisor);
			} else {
				
				TelaTesteFinal02.SetActive (false);
				gameObject.GetComponent<AudioSource> ().PlayOneShot (quizFail);
				ResultadoReprovado.SetActive (true);


			}
		}

	}

	public void iniciarTeste ()
	{
		if (checkTesteFinal == 1) {
			TelaTesteFinal.SetActive (false);
			ResultadoFinal.SetActive (true);
		} else {
			TelaTesteFinal.SetActive (false);
			TelaTesteFinal02.SetActive (true);
			Time.timeScale = 0;
			acertos = 0;
			duplo = 1; 
			idPergunta = 0;
			questoes = perguntas.Length;
			pergunta.text = perguntas[idPergunta];
			respostaA.text = alternativaA[idPergunta];
			respostaB.text = alternativaB[idPergunta];
			respostaC.text = alternativaC[idPergunta];
			respostaD.text = alternativaD[idPergunta];
		}
	}

	public void fecharTodasTelas(){
		ResultadoFinal.SetActive (false);
		ResultadoReprovado.SetActive (false);
		TelaTesteFinal.SetActive (false);
		TelaTesteFinal02.SetActive (false);
		Time.timeScale = 1;
	}

	IEnumerator Pausa(){
		yield return new WaitForSeconds (3);

	}
	IEnumerator Pausa2(){

		yield return new WaitForSeconds (1);
		proximaPergunta();
	}

}
