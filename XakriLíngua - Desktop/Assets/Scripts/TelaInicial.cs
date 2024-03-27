using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaInicial : MonoBehaviour {

	public Button aventura;
	public int tema1;
	public int tema2;
	public int tema3;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		this.tema1 = PlayerPrefs.GetInt ("tema1");
		this.tema2 = PlayerPrefs.GetInt ("tema2");
		this.tema3 = PlayerPrefs.GetInt ("tema3");	
	}
	
	// Update is called once per frame
	void Update () {
		if((tema1 == 1)&&(tema2 == 1)&&(tema3 ==1)){
			aventura.interactable = true;
		}
	}
}
