using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour {

	private int idTema;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text infoResposta;

	public Sprite[] afirmacao;
	public Sprite semImagem;
	public Image[] imagem;

	public string[] perguntas; //armazena todas as perguntas
	public string[] alternativaA; //armazena todas as alternativas A
	public string[] alternativaB; //armazena todas as alternativas B
	public string[] alternativaC; //armazena todas as alternativas C
	public string[] alternativaD; //armazena todas as alternativas D
	public string[] corretas; //armazena todas as alternativas corretas

	private int idPergunta;

	private float acertos;
	private float questoes;
	private float media;
	private int notaFinal;
	public AudioClip correto, erro;
	public int duplo = 1;



	private int idImagem = 0;
	private int contador;
	public Sprite[] imagens;
	public Image objeto;

	// Use this for initialization
	void Start () {
		contador = imagens.Length;
	 	duplo =1;
		idTema = PlayerPrefs.GetInt ("idTema"); 
		idPergunta = 0;
		questoes = perguntas.Length;
		pergunta.text = perguntas[idPergunta];
		respostaA.text = alternativaA[idPergunta];
		respostaB.text = alternativaB[idPergunta];
		respostaC.text = alternativaC[idPergunta];
		respostaD.text = alternativaD[idPergunta];
		infoResposta.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString () + " perguntas.";
	}


	public void resposta (string alternativa)
	{
		if (duplo > 0) {
			if (alternativa == "A") {
				if (alternativaA [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					TocarSom (true);
					imagem [0].sprite = afirmacao [0];
					StartCoroutine (Pausa2 ());
					duplo--;
				} else {
					TocarSom (false);
					imagem [1].sprite = afirmacao [1];
					StartCoroutine (Pausa2 ());
					duplo--;
				}
			} else if (alternativa == "B") {
				if (alternativaB [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					TocarSom (true);
					imagem [2].sprite = afirmacao [0];
					StartCoroutine (Pausa2 ());
					duplo--;
				} else {
					TocarSom (false);
					imagem [3].sprite = afirmacao [1];
					StartCoroutine (Pausa2 ());
					duplo--;
				} 
			} else if (alternativa == "C") {
				if (alternativaC [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					TocarSom (true);
					imagem [4].sprite = afirmacao [0];
					StartCoroutine (Pausa2 ());
					duplo--;
				} else {
					TocarSom (false);
					imagem [5].sprite = afirmacao [1];
					StartCoroutine (Pausa2 ());
					duplo--;
				}
			} else if (alternativa == "D") {
				if (alternativaD [idPergunta] == corretas [idPergunta]) {
					acertos += 1;
					TocarSom (true);
					imagem [6].sprite = afirmacao [0];
					StartCoroutine (Pausa2 ());
					duplo--;
				} else {
					TocarSom (false);
					imagem [7].sprite = afirmacao [1];
					StartCoroutine (Pausa2 ());
					duplo--;
				}
			}
			StartCoroutine (Pausa ());
		}
	}

	IEnumerator Pausa(){

		yield return new WaitForSeconds (2);
		proximaPergunta();
	}
	IEnumerator Pausa2(){

		yield return new WaitForSeconds (1);
	}


	void proximaPergunta(){
		proximoObjeto ();
		duplo = 1;
		idPergunta += 1;
		imagem [0].sprite = semImagem;
		imagem[1].sprite = semImagem;
		imagem[2].sprite = semImagem;
		imagem[3].sprite = semImagem;
		imagem[4].sprite = semImagem;
		imagem[5].sprite = semImagem;
		imagem[6].sprite = semImagem;
		imagem[7].sprite = semImagem;

		if (idPergunta <= questoes-1) {
			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];
			infoResposta.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
		} else {

			media = 10 * (acertos / questoes);
			notaFinal = Mathf.RoundToInt (media);

			if (notaFinal > PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ())) {
				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString(), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString(), (int) acertos);
			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString(), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString(), (int) acertos);
			SceneManager.LoadScene ("notaFinal");
		}
	}
	void TocarSom(bool som){ // método requerindo uma variavel booleana
		if(som){
			// tocar som verdadeiro
			gameObject.GetComponent<AudioSource>().PlayOneShot(correto); // manda tocar 1 vez o audio de acerto
		}
		else{
			// tocar som falso
			gameObject.GetComponent<AudioSource>().PlayOneShot(erro); //  manda tocar 1 vez o audio de erro
		}
	}
	public void proximoObjeto ()
	{
		idImagem += 1;
		if (idImagem < contador) {
			objeto.sprite = imagens [idImagem];

		}
	}
		

}
