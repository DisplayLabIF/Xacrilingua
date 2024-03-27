using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerAtack : MonoBehaviour {

	private float tempoEntreAtaque;
	public float startTempoEntreAtaque;
	public float acaoDistancia;
	public float ataqueRange;

	public Transform ataquePos;
	public Transform chatPos;
	public Transform acaoPos;
	public Transform firePoint;
	public Transform detectorDeChao;
	public Transform myTransform;

	public LayerMask whatIsEnemies;
	public LayerMask whatIsNPC;
	public LayerMask whatIsMoeda;

	public int health;
	public int damage;
	private int QualAventura;
	public int coins;

	public GameObject hp1;
	public GameObject hp2;
	public GameObject hp3;
	public GameObject acao;
	public GameObject itemBau;

	public GameObject pause;
	public GameObject completo;
	public Animator animador;
	private RaycastHit2D chaoInfo;

	public AudioClip hit;
	public AudioClip somCompletar;
	public AudioClip morteCobra;
	public AudioClip slide;
	public Text txtMoedas;
	public GameObject GameController;
	public int verificador01;
	public int verificador02;
	public int verificador03;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update (){
		txtMoedas.text = coins.ToString ();
		VerificarHP ();
		Slide();

	}

	public void Slide ()
	{
		if (tempoEntreAtaque <= 0) {
			if (Input.GetKey (KeyCode.X)) {
				animador.SetBool ("Slide", true);
				gameObject.GetComponent<AudioSource> ().PlayOneShot (slide);
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (ataquePos.position, ataqueRange, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++) {
					if (enemiesToDamage [i].GetComponent<Enemy> ().isFantasma == false) {
						enemiesToDamage [i].GetComponent <Enemy> ().health -= damage;
						enemiesToDamage [i].GetComponent <Enemy> ().ataqueRange = 0;
						gameObject.GetComponent<AudioSource> ().PlayOneShot (hit, 0.3f);
						gameObject.GetComponent<AudioSource> ().PlayOneShot (morteCobra, 1f);
					}
				}
				tempoEntreAtaque = startTempoEntreAtaque;
			} else {
				animador.SetBool ("Slide", false);
			}
		} else {
			tempoEntreAtaque -= Time.deltaTime;
		}
			
	}

	public void SlideAndroid()
	{
		if (tempoEntreAtaque <= 0) {
			animador.SetBool ("Slide", true);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (slide);
			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (ataquePos.position, ataqueRange, whatIsEnemies);
			for (int i = 0; i < enemiesToDamage.Length; i++) {
				if (enemiesToDamage [i].GetComponent<Enemy> ().isFantasma == false) {
					enemiesToDamage [i].GetComponent <Enemy> ().health -= damage;
					enemiesToDamage [i].GetComponent <Enemy> ().ataqueRange = 0;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (hit, 0.3f);
					gameObject.GetComponent<AudioSource> ().PlayOneShot (morteCobra, 1f);
				}
			}
			tempoEntreAtaque = startTempoEntreAtaque;
		} else {
			animador.SetBool ("Slide", false);
		}
	}

	public void somarMoedas (int moedas){
		coins += moedas;
	}

	//PROCEDIMENTO PARA VERIFICAR QUANTO TEM DE HP PARA ATIVAR OS CORAÇÕES
	public void VerificarHP(){
		if (health == 3) {
			hp1.SetActive (true);
			hp2.SetActive (true);
			hp3.SetActive (true);
		} else if (health >= 2) {
			hp1.SetActive (true);
			hp2.SetActive (true);
			hp3.SetActive (false);
		} else if (health >= 1) {
			hp1.SetActive (true);
			hp2.SetActive (false);
			hp3.SetActive (false);
		} else {
			hp1.SetActive (false);
			hp2.SetActive (false);
			hp3.SetActive (false);
			animador.SetBool ("morto", true);
			StartCoroutine( Pausa ());

		}
	}

	//METODO PARA QUANDO ENTRAR EM COLISAO COMPARADO POR TAG
	void OnCollisionEnter2D (Collision2D outro)
	{
		//CONDICIONAL PARA VERIFICAR SE O ITEM É HP
		if (outro.gameObject.CompareTag ("hp")) {
			outro.gameObject.SetActive (false);
			Destroy (Instantiate (outro.gameObject));
			//VERIFICAR QUANTOS CORAÇÕES POSSUI E QUANTOS PODE RECEBER
			if (health == 3) {
				health = 3;
			} else if (health == 2) {
				health = 3;
			} else if (health == 1)
				health = 2;
		}
		//CONDICIONAL PARA PEGAR O ITEM ATRAVÉS DA TAG

		if (outro.gameObject.CompareTag ("recompensa")) {
			outro.gameObject.SetActive (false);
			Destroy (itemBau);
			completo.SetActive (true);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (somCompletar);
			StartCoroutine (Finish());
		}

		if (outro.gameObject.CompareTag ("recompensa2")) {
			completo.SetActive (true);
			animador.SetBool ("noChao", true);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (somCompletar);
			StartCoroutine (Finish());
		}


		if (outro.gameObject.CompareTag ("item")) {
			itemBau.SetActive (false);
			Destroy (itemBau);
		}

		//COLISAO PARA TER 
		if (outro.gameObject.CompareTag ("enemy")) {
			animador.SetBool ("noChao", true);
		}

		if (outro.gameObject.CompareTag ("agua")) {
			Destroy (gameObject);
		}

		if (outro.transform.tag == "canoa") {
			myTransform.parent = outro.transform;
			animador.SetBool ("noChao", true);	
		}
	}

	void OnCollisionExit2D (Collision2D outro){
		if (outro.transform.tag == "canoa") {
			myTransform.parent = outro.transform;	
		}
	}

	//METODO PARA RECEBER DAMAGE
	public void takeDamage (int damage)
	{
		health -= damage;
	}


	//DELAY PARA ITEM SAIR DO BAÚ
	IEnumerator itemDelay ()
	{
		yield return new WaitForSeconds (2);
	}

	//MOSTRAR RANGE DE ATAQUE
	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (ataquePos.position, ataqueRange);
		Gizmos.DrawWireSphere (chatPos.position, acaoDistancia);
	}

	public void completarFase ()
	{
		
		//int verificador01 = GameController.GetComponent<Aventura01> ().currentAventura;
		if (verificador01 == 1) {
			PlayerPrefs.SetInt ("aventura01", 1);
			SceneManager.LoadScene ("LoadScreenMenuAventura");
		}

		if (verificador02 == 1) {
			PlayerPrefs.SetInt ("aventura02", 1);
			SceneManager.LoadScene ("LoadScreenMenuAventura");
		}

		if (verificador03 == 1) {
			PlayerPrefs.SetInt ("aventura03", 1);
			SceneManager.LoadScene ("LoadScreenMenuAventura");
		}
			
	}

	//DELAY PARA DESTRUIR O OBJETO
	IEnumerator Pausa(){
		yield return new WaitForSeconds (1);
		Destroy (gameObject);

		if (verificador01 == 1) {
			PlayerPrefs.SetInt ("aventura01", 1);
			SceneManager.LoadScene ("LoadScreenAventura01");
		}

		if (verificador02 == 1) {
			PlayerPrefs.SetInt ("aventura02", 1);
			SceneManager.LoadScene ("LoadScreenAventura02");
		}

		if (verificador03 == 1) {
			PlayerPrefs.SetInt ("aventura03", 1);
			SceneManager.LoadScene ("LoadScreenAventura03");
		}
	}
	IEnumerator Pausa2(){
		yield return new WaitForSeconds (1);
		animador.SetBool ("Slide", false);
	}

	IEnumerator Finish(){
		yield return new WaitForSeconds (4);
		completarFase ();
	}
}
