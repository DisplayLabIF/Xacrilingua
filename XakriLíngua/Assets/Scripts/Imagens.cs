using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagens : MonoBehaviour {

	//public Image imagens;
	//public string carregarImagem;
	// Use this for initialization
	//public bool trocarImagem;
	public int idImagem;
	private int contador;
	public Sprite[] imagens;
	public Image objeto;
	public Text portuguesTexto;
	public Text xakriabaTexto;
	public string[] portugues;
	public string[] xakriaba;

	void Start () {
		idImagem = 0;
		contador = imagens.Length;
		portuguesTexto.text = portugues[idImagem];
		xakriabaTexto.text = xakriaba[idImagem];
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void proximoObjeto ()
	{
		idImagem += 1;
		if (idImagem >= 10) {
			idImagem = 0;
		}
		if (idImagem < contador) {
			portuguesTexto.text = portugues [idImagem];
			xakriabaTexto.text = xakriaba [idImagem];
			objeto.sprite = imagens [idImagem];
		}

	}


	public void ObjetoAnterior ()
	{
		idImagem -= 1;
		if (idImagem == -1) {
			idImagem = 9;
		}
		if (idImagem < contador) {
			portuguesTexto.text = portugues [idImagem];
			xakriabaTexto.text = xakriaba [idImagem];
			objeto.sprite = imagens [idImagem];
		}

	}
}
