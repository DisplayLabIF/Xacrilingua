using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour {

	public float delay = 0.1f;
	public string textoCompleto;
	private string currentText = "";
		// Use this for initialization
	void Start () {
		StartCoroutine (ShowText());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator ShowText ()
	{
		for (int i = 0; i <= textoCompleto.Length; i++) {
			currentText = textoCompleto.Substring (0, i);
			this.GetComponent <Text>(). text = currentText;
			yield return new WaitForSeconds (delay);
		}
	}
}
