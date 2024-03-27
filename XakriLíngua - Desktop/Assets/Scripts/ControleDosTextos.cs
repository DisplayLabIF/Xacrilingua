using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDosTextos : MonoBehaviour {
	public GameObject texto00;
	public GameObject texto01;
	public GameObject texto02;
	public GameObject texto03;
	public GameObject texto04;
	public GameObject texto05;
	public GameObject texto06;
	public GameObject texto07;
	public GameObject texto08;
	public GameObject texto09;
	public GameObject texto10;
	public GameObject texto11;


	// Use this for initialization
	void Start () {
		StartCoroutine (Mostrar00 ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Mostrar00 ()
	{
		yield return new WaitForSeconds (9);
		StartCoroutine (Mostrar01 ());
		texto01.SetActive (true);
	}
	IEnumerator Mostrar01 ()
	{
		
		yield return new WaitForSeconds (7);
		StartCoroutine (Mostrar02 ());
		texto02.SetActive (true);

	}
	IEnumerator Mostrar02 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar03 ());
		texto03.SetActive (true);
	}
	IEnumerator Mostrar03 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar04 ());
		texto04.SetActive (true);
	}
	IEnumerator Mostrar04 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar05 ());
		texto05.SetActive (true);
	}
	IEnumerator Mostrar05 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar06 ());
		texto06.SetActive (true);
	}
	IEnumerator Mostrar06 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar07 ());
		texto07.SetActive (true);
	}
	IEnumerator Mostrar07 ()
	{
		yield return new WaitForSeconds (7);
		StartCoroutine (Mostrar08 ());
		texto08.SetActive (true);
	}
	IEnumerator Mostrar08 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar09 ());
		texto09.SetActive (true);
	}
	IEnumerator Mostrar09 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar10 ());
		texto10.SetActive (true);
	}
	IEnumerator Mostrar10 ()
	{
		yield return new WaitForSeconds (3);
		StartCoroutine (Mostrar11 ());
		texto11.SetActive (true);
	}
	IEnumerator Mostrar11 ()
	{
		yield return new WaitForSeconds (3);
	}


}
