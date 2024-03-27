using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jogarNovamente : MonoBehaviour {

	private int idTema;

	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt ("idTema");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void repetir(){
		SceneManager.LoadScene("LoadScreenT" + idTema.ToString());
	}
}
