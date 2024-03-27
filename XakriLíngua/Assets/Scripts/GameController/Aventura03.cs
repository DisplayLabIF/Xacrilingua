using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aventura03 : MonoBehaviour {

	public float tempoEntreAtaque;
	private float startTempoEntreAtaque;
	public float acaoDistancia;
	public float ataqueRange;

	public Transform ataquePos;
	public Transform chatPos;
	public Transform acaoPos;
	public Transform firePoint;
	public Transform detectorDeChao;
	public Transform myTransform;

	public LayerMask whatIsNPC;
	public LayerMask whatIsBilhete;
	public LayerMask whatIsBau;
	public LayerMask whatIsCanoa;
	public LayerMask whatIsCuriosidade01;
	public LayerMask whatIsCuriosidade02;
	public LayerMask whatIsCuriosidade03;
	public LayerMask whatIsTesteFinal;

	public GameObject curiosidade01;
	public GameObject curiosidade02;
	public GameObject curiosidade03;

	int alhoRestante = 10;
	int qntPassagem = 1;
	int duplo = 1;
	public Text txtAlhoRestante;

	private float velocidade;

	public GameObject chat01;
	public GameObject chat02;
	public GameObject chat03;
	public GameObject item_hud;
	public GameObject projetil;
	public GameObject acao;
	public GameObject jogador;
	public GameObject txtAlho;
	public GameObject itemBau;
	public GameObject bau;
	public GameObject smokePuff;
	public GameObject btnArremesso;
	public GameObject limitadorFinal;
	public GameObject telaTesteFinal;



	public GameObject missao01;
	public GameObject missao02;
	public GameObject missao03;
	public GameObject lblMissao01;
	public GameObject lblMissao02;
	public GameObject lblMissao03;
	public int missao01Status;
	public int missao02Status;
	public int missao03Status;
	public GameObject efeitoMissao01;
	public GameObject efeitoMissao02;
	public GameObject efeitoMissao03;
	public GameObject efeitoArremesso;
	public GameObject efeitoBau;
	public GameObject efeitoCanoa01;
	public GameObject efeitoNpc01;
	public GameObject efeitoBilhete;
	public GameObject efeitoFragmento01;
	public GameObject efeitoFragmento02;
	public GameObject efeitoFragmento03;
	public int fantasmasMortos;
	public int cobrasMortas;

	public AudioClip somCompra;
	public AudioClip moedaSom;
	public AudioClip somItem;
	public AudioClip somSmoke;


	private int chatCheck01;
	private int chatCheck02;
	public Animator animador;
	public Animator abrirBau;
	public Animator smokePuff2;
	public GameObject rio;
	public GameObject rio2;
	public GameObject buraco;
	public Image btnArremeco;
	public Sprite btnArremecoNull;
	public Sprite btnArremecoAtivo;


	private bool item;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		jogador.GetComponent <PlayerAtack> ().verificador03 = 1;
		rio.GetComponent<Rio> ().verificador03 = 1;
		rio2.GetComponent<Rio> ().verificador03 = 1;
		buraco.GetComponent<Rio> ().verificador03 = 1;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (fantasmasMortos == 5) {
			missao02.SetActive (true);
			efeitoMissao01.SetActive (true);
			StartCoroutine (Missao02Delay ());
		}

		if (missao01Status == 1) {
			lblMissao01.SetActive (false);
			missao01.SetActive (false);
			lblMissao02.SetActive (true);
		}


		if (missao02Status == 1) {
			lblMissao02.SetActive (false);
			missao02.SetActive (false);
			lblMissao03.SetActive (true);
			StartCoroutine (Missao02Delay ());
		}


		if (missao03Status == 1) {
			lblMissao03.SetActive (false);
			missao03.SetActive (false);
		}

	}

	public void AbrirBau(){
			Collider2D[] bauToOpen = Physics2D.OverlapCircleAll (acaoPos.position, acaoDistancia, whatIsBau);
			for (int i = 0; i < bauToOpen.Length; i++) {
				abrirBau.SetBool ("fechado", true);
				abrirBau.SetBool ("abrir", true);
				abrirBau.SetBool ("aberto", true);
				itemBau.SetActive (true);
				gameObject.GetComponent<AudioSource> ().PlayOneShot (somItem);
				item_hud.SetActive (true);
				alhoRestante = 10;
				item = true;
				txtAlhoRestante.text = alhoRestante.ToString ();
				txtAlho.SetActive (true);
				btnArremeco.sprite = btnArremecoAtivo;
				efeitoArremesso.SetActive (true);
				efeitoBau.SetActive (false);
			}
	}

	public void Arremessar ()
	{
		if (item == true) {
			animador.SetBool ("jogar", true);
			if (alhoRestante > 0) {
				if (duplo > 0) {
					Shoot ();
					duplo--;
					StartCoroutine (shootDelay ());
					alhoRestante--;

				} 
				txtAlhoRestante.text = alhoRestante.ToString ();
			}
			if (alhoRestante == 0) {
				animador.SetBool ("jogar", false);
				item = false;
				item_hud.SetActive (false);
				txtAlho.SetActive (false);
				txtAlhoRestante.text = "";
				btnArremeco.sprite = btnArremecoNull;
				efeitoArremesso.SetActive (false);
			}
		}
	}

	void Shoot(){
		
		Instantiate (projetil, firePoint.position, firePoint.rotation);
	}

	public void EntrarCanoa ()
	{
		Collider2D[] andarCanoa = Physics2D.OverlapCircleAll (acaoPos.position, acaoDistancia, whatIsCanoa);
		for (int i = 0; i < andarCanoa.Length; i++) {
				andarCanoa [i].GetComponent <Alho> ().m_Velocidade = 250;
				qntPassagem--;
				missao01.SetActive (true);
				efeitoMissao01.SetActive (true);
				StartCoroutine (Missao01Delay ());
				efeitoCanoa01.SetActive (false);
		}
	}

	public void AbrirBilhete(){
		Collider2D[] bilheteParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsBilhete);
		for (int i = 0; i < bilheteParaAbrir.Length; i++) {
				chat01.SetActive (true);
				efeitoBilhete.SetActive (false);
		}
	}

	public void AbrirChatFinal(){
		Collider2D[] npcToChatFinal = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPC);
		for (int i = 0; i < npcToChatFinal.Length; i++) {
				chat03.SetActive (true);
				efeitoNpc01.SetActive (false);
		}
	}

	public void AbrirBilhete02 (){
		chat01.SetActive (false);
		chat02.SetActive (true);
	}


	public void AbrirCuriosidade01(){
		Collider2D[] curiosidade01ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade01);
		for (int i = 0; i < curiosidade01ParaAbrir.Length; i++) {
				curiosidade01.SetActive (true);
				efeitoFragmento01.SetActive (false);
				Time.timeScale = 0;
		}
	}

	public void AbrirCuriosidade02(){
		Collider2D[] curiosidade02ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade02);
		for (int i = 0; i < curiosidade02ParaAbrir.Length; i++) {
				curiosidade02.SetActive (true);
				efeitoFragmento02.SetActive (false);
				Time.timeScale = 0;
		}
	}

	public void AbrirCuriosidade03(){
		Collider2D[] curiosidade03ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade03);
		for (int i = 0; i < curiosidade03ParaAbrir.Length; i++) {
				curiosidade03.SetActive (true);
				efeitoFragmento03.SetActive (false);
				Time.timeScale = 0;
		}
	}

	public void AbrirTesteFinal(){
		Collider2D[] testeFinal = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsTesteFinal);
		for (int i = 0; i < testeFinal.Length; i++) {
				telaTesteFinal.SetActive (true);
		}
	}

	public void FecharTodosChats ()
	{
		chat01.SetActive (false);
		chat02.SetActive (false);
		chat03.SetActive (false);
	}

	public void fecharTodasCuriosidades (){
		curiosidade01.SetActive (false);
		curiosidade02.SetActive (false);
		curiosidade03.SetActive (false);
		Time.timeScale = 1;
	}

	public void fecharChatFinal(){
		chat03.SetActive (false);
		Destroy (limitadorFinal);
		missao03.SetActive (true);
		efeitoMissao03.SetActive (true);
		StartCoroutine (Missao03Delay ());
	}

	public void Restart03(){
		SceneManager.LoadScene ("LoadScreenAventura03");
	}

	public void MenuPrincipal (){
		SceneManager.LoadScene ("LoadScreenMenuAventura");
	}

	IEnumerator shootDelay (){
		yield return new WaitForSeconds (1);
		animador.SetBool ("jogar", false);
		duplo = 1;
	}

	IEnumerator Smoke(){
		yield return new WaitForSeconds (1);
		smokePuff.SetActive (false);
		bau.SetActive (true);
	}

	IEnumerator Missao01Delay(){
		yield return new WaitForSeconds (2);
		missao01Status = 1;
		efeitoMissao01.SetActive (false);
	}

	IEnumerator Missao02Delay(){
		yield return new WaitForSeconds (2);
		missao02Status = 1;
		efeitoMissao02.SetActive (false);
	}

	IEnumerator Missao03Delay(){
		yield return new WaitForSeconds (2);
		missao03Status = 1;
		efeitoMissao03.SetActive (false);
	}
	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (ataquePos.position, ataqueRange);
		Gizmos.DrawWireSphere (chatPos.position, acaoDistancia);
	}
}
