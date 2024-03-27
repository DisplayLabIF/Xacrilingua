using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private float tempoEntreAtaque;
	public float startTempoEntreAtaque;
	public float velocidade;
	public float distancia;
	private bool movendoDireita = true;
	public int health;
	public Animator animacao;
	public Animator player;
	public Transform ataquePos;
	public float ataqueRange;
	public LayerMask whatIsPlayer;
	public int damage;
	public Transform detectorDeChao;
	public Transform presas;
	public AudioClip morteFantasma;
	public int tempoParaMorrer;
	private int chance;
	//public GameObject meat;
	public GameObject jogador;
	public GameObject GameController;

	public bool isFantasma;
	public RaycastHit2D chaoInfo;
	public RaycastHit2D ataque;
	public AudioClip playerHit;
	private int duplo = 1;

	void Start(){
		//Destroy (Instantiate (meat));
		animacao.SetBool ("noChao", true);
		Fantasma ();
	


	}

	void Update ()
	{

		if (health == 0) {
			animacao.SetBool ("hit2", true);
			velocidade = 0;
			ataqueRange = 0;
			StartCoroutine (Pausa ());
			
		}
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
		chaoInfo = Physics2D.Raycast (detectorDeChao.position, Vector2.down, distancia);
		ataque = Physics2D.Raycast (presas.position, Vector2.right, 1);
		if (chaoInfo.collider == false) {
			if (movendoDireita == true) {
				transform.eulerAngles = new Vector3 (0, -180, 0);
				movendoDireita = false;
			} else {
				transform.eulerAngles = new Vector3 (0, 0, 0);
				movendoDireita = true;
			}
		}


		//ATAQUE DO INIMIGO
		if ((tempoEntreAtaque <= 0) && (ataqueRange != 0)) {
			Collider2D[] playersToDamage = Physics2D.OverlapCircleAll (ataquePos.position, ataqueRange, whatIsPlayer);
			for (int i = 0; i < playersToDamage.Length; i++) {
				playersToDamage [i].GetComponent <PlayerAtack> ().health -= damage;
				player.SetBool ("hit",true);
				playersToDamage[i].GetComponent<AudioSource> ().PlayOneShot (playerHit,1f);
			}
			tempoEntreAtaque = startTempoEntreAtaque;
		} else {
			tempoEntreAtaque -= Time.deltaTime;
			player.SetBool ("hit",false);
		}
	}

	//METODO PARA DROPAR ITEM
//	private void OnDestroy ()
//	{
//		int chance = Random.Range (0, 4);
//
//		if (chance == 0) {
//			Instantiate (meat,transform.position, meat.transform.rotation);
//
//		}
//	}

	//METODO PARA RECEBER DAMAGE
	public void takeDamage (int damage)
	{
		health -= damage;
	}

	//METODO DE COLISAO COMPARADO POR TAG

	void Fantasma ()
	{
		if (transform.CompareTag ("fantasma")) {
			isFantasma = true;	
		} else {
			isFantasma = false;
		}
	}

	//DELAY DE TEMPO PARA EXECUCAO DE TAREFA
	IEnumerator Pausa ()
	{
		yield return new WaitForSeconds (1);
		if (gameObject.CompareTag ("lacraia")) {
			if (duplo > 0) {
				GameController.GetComponent <Aventura01> ().lacraiasMortas++;
				Destroy (gameObject);
				duplo--;
			}
		} 

		if (gameObject.CompareTag ("enemy")) {
			if (duplo > 0) {
				Destroy (gameObject);
				duplo--;
			}
		}

		if (gameObject.CompareTag ("enemy1")) {
			if (duplo > 0) {
				GameController.GetComponent <Aventura03> ().cobrasMortas++;
				Destroy (gameObject);
				duplo--;
			}
		}
	}


	void OnCollisionEnter2D (Collision2D outro)
	{
		if (outro.gameObject.CompareTag ("projetil")) {
			
			jogador.GetComponent<AudioSource> ().PlayOneShot (morteFantasma, 0.5f);
			GameController.GetComponent <Aventura02> ().fantasmasMortos++;
			Destroy(gameObject);
		}
		if (outro.gameObject.CompareTag ("projetil02")) {
			
			jogador.GetComponent<AudioSource> ().PlayOneShot (morteFantasma, 0.5f);
			GameController.GetComponent <Aventura03> ().fantasmasMortos++;
			Destroy(gameObject);
		}
	}

	//MOSTRAR RANGE DE ATAQUE
	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (ataquePos.position, ataqueRange);
	}


}