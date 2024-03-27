using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opcoes : MonoBehaviour {

public GameObject dialog;
public GameObject dialog2;
public float volumeMusic;
public float volumeSfx;
public Slider sldMusica;
public Slider sldSfx;

		// Use this for initialization
	void Start ()
	{
		sldMusica.value = PlayerPrefs.GetFloat ("volumeMusic");
		sldSfx.value = PlayerPrefs.GetFloat ("volumeSFX");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void resetarPontuacoes(){
		PlayerPrefs.DeleteAll ();
		dialog.SetActive (false);
		dialog2.SetActive (true);
		PlayerPrefs.SetFloat ("volumeMusic", 0.5f);
		sldMusica.value = 0.5f;
		PlayerPrefs.SetFloat ("volumeSFX", 0.5f);
		sldSfx.value = 0.5f;
	}
	public void abrirDialog(){
		dialog.SetActive (true);
	}
	public void fecharDialog (){
		dialog.SetActive (false);
		dialog2.SetActive (false);
	}

	public void volumeMusica(){
		volumeMusic = sldMusica.value;
		PlayerPrefs.SetFloat ("volumeMusic", volumeMusic);
	}
	public void volumeSFX(){
		volumeSfx = sldSfx.value;
		PlayerPrefs.SetFloat ("volumeSFX", volumeSfx);
	}

}
