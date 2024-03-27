using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScreen : MonoBehaviour {

	public string cenaCarregar;
	public float tempoFixoSeg = 5;
	public enum tipoCarreg{carregamento,tempoFixo};
	public tipoCarreg tipoDeCarregamento;
	public Image barraDeCarregamento;
	public Text textoProgresso;
	private int progresso;
	private string textoOriginal;

	// Use this for initialization
	void Start () {
		progresso = 1;
		switch (tipoDeCarregamento) {
		case tipoCarreg.carregamento:
			StartCoroutine (cenaDeCarregamento (cenaCarregar));
			break;
		case tipoCarreg.tempoFixo:
			StartCoroutine (tempoFixo (cenaCarregar));
			break;
		}
		if (textoProgresso != null) {
			textoOriginal = textoProgresso.text;
		}

		if (barraDeCarregamento != null) {
			barraDeCarregamento.type = Image.Type.Filled;
			barraDeCarregamento.fillMethod = Image.FillMethod.Horizontal;
			barraDeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
		} 
	}
		IEnumerator cenaDeCarregamento(string cena){
			AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
			while(!carregamento.isDone){
				progresso = (int)(carregamento.progress * 100.0f);
				yield return null;
			}
		}
		
		IEnumerator tempoFixo(string cena){
			yield return new WaitForSeconds (tempoFixoSeg);
			SceneManager.LoadScene (cena);
		}
		
	// Update is called once per frame
	void Update () {
		switch (tipoDeCarregamento) {
			case tipoCarreg.carregamento:
			break;
			case tipoCarreg.tempoFixo:
			progresso = (int)(Mathf.Clamp((Time.time / tempoFixoSeg),0.0f,1.0f)* 100.0f);
			break;
		}
		if(textoProgresso != null){
			textoProgresso.text = textoOriginal + " " + progresso + "%";
		}

		if(barraDeCarregamento != null){
			barraDeCarregamento.fillAmount = (progresso / 100.0f);
		}

	}
}
