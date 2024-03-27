using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour {

	public bool isPause;
	public GameObject pause;
	public GameObject opcao;
	public void  Pause(){
		Time.timeScale = 0;
		pause.SetActive (true);
	}

	public void UnPause ()
	{
		Time.timeScale = 1;
		pause.SetActive (false);
	}
	// Update is called once per frame
	void Update ()
	{
	}
	public void AbrirOpcao(){
		opcao.SetActive (true);
		pause.SetActive (false);
	}
	public void fecharOpcao(){
		opcao.SetActive (false);
		pause.SetActive (true);
	}


}

