using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aventura02 : MonoBehaviour {

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
	public LayerMask whatIsNPCLoja;
	public LayerMask whatIsNPCMensagem;
	public LayerMask whatIsNPCFinal;
	public LayerMask whatIsLoja;
	public LayerMask whatIsBau;
	public LayerMask whatIsCanoa;
	public LayerMask whatIsCuriosidade01;
	public LayerMask whatIsCuriosidade02;
	public LayerMask whatIsCuriosidade03;
	public LayerMask whatIsTesteFinal;

	public GameObject curiosidade01;
	public GameObject curiosidade02;
	public GameObject curiosidade03;

	private int precoPassagem = 15;
	private int precoItem = 5;
	private int alhoRestante = 10;
	private int qntPassagem = 1;
	private int estoqueAlho = 20;
	private int duplo = 1;
	public Text txtAlhoRestante;

	private float velocidade;

	public GameObject chatCanoa1;
	public GameObject chatCanoa2;
	public GameObject chatCanoa3;
	public GameObject chatVendedora1;
	public GameObject chatVendedora2;
	public GameObject chatVendedora3;
	public GameObject chatVendedora4;
	public GameObject chatVendedora5;
	public GameObject chatVendedora6;
	public GameObject chatFinal;
	public GameObject chatMensagem;
	public GameObject item_hud;
	public GameObject projetil;
	public GameObject acao;
	public GameObject jogador;
	public GameObject txtAlho;
	public GameObject itemBau;
	public GameObject bau;
	public GameObject smokePuff;

	public GameObject missao01;
	public GameObject missao02;
	public GameObject missao03;
	public GameObject lblMissao01;
	public GameObject lblMissao02;
	public GameObject lblMissao03;
	public int missao01Status;
	public int missao02Status;
	public int missao03Status;
	public GameObject efeitoArremesso;
	public GameObject efeitoMissao01;
	public GameObject efeitoMissao02;
	public GameObject efeitoMissao03;
	public GameObject efeitoFragmento01;
	public GameObject efeitoFragmento02;
	public GameObject efeitoFragmento03;
	public GameObject efeitoNPC01;
	public GameObject efeitoNPC02;
	public GameObject efeitoNPC03;
	public GameObject efeitoNPC04;
	public GameObject efeitoBau;

	public GameObject telaTesteFinal;
	public int fantasmasMortos;

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
	public Image btnArremeco;
	public Sprite btnArremecoNull;
	public Sprite btnArremecoAtivo;
	public float notafinal;
	public float cooldown;
	public float coolDownTimer;


	private bool item;

	// Use this for initialization
	void Start () {
		jogador.GetComponent <PlayerAtack> ().verificador02 = 1;
		rio.GetComponent<Rio> ().verificador02 = 1;
		lblMissao01.SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (fantasmasMortos == 6) {
			missao03.SetActive (true);
			efeitoMissao03.SetActive (true);
			StartCoroutine (Missao03Delay ());
		} else {
			missao03.SetActive (false);
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
		}


		if (missao03Status == 1) {
			lblMissao03.SetActive (false);
			missao03.SetActive (false);

		}

		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		}

		if (coolDownTimer < 0) {
			coolDownTimer = 0;
		}

		if((Input.GetKey (KeyCode.C)) && (coolDownTimer == 0)){
			coolDownTimer = cooldown;
			Arremessar ();
		}

		AbrirBau ();
		AbrirCuriosidade01 ();
		AbrirCuriosidade02 ();
		AbrirCuriosidade03 ();
		AbrirChatCanoa ();
		AbrirChatFinal ();
		AbrirChatMensagem ();
		fecharTodasCuriosidades ();
		AbrirTesteFinal ();
		chatLoja1 ();
	}

	public void AbrirBau ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] bauToOpen = Physics2D.OverlapCircleAll (acaoPos.position, acaoDistancia, whatIsBau);
			for (int i = 0; i < bauToOpen.Length; i++) {
				abrirBau.SetBool ("fechado", true);
				abrirBau.SetBool ("abrir", true);
				abrirBau.SetBool ("aberto", true);
				itemBau.SetActive (true);
				efeitoBau.SetActive (false);
				gameObject.GetComponent<AudioSource> ().PlayOneShot (somItem);
			}
		}
	}

	public void AparecerBau()
	{
		if (chatCheck02 != 1) {
			chatFinal.SetActive (false);
			smokePuff.SetActive (true);
			smokePuff2.SetBool ("explodir", true);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (somSmoke);
			StartCoroutine (Smoke ());
			chatCheck02 = 1;
		} else {
			chatFinal.SetActive (false);
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
		}
		if (alhoRestante == 0) {
			animador.SetBool ("jogar", false);
			item = false;
			item_hud.SetActive (false);
			txtAlho.SetActive (false);
			efeitoArremesso.SetActive (false);
			txtAlhoRestante.text = "";
			btnArremeco.sprite = btnArremecoNull;
		}
	}

	void Shoot(){
		Instantiate (projetil, firePoint.position, firePoint.rotation);
	}

	public void EntrarCanoa ()
	{
		chatCanoa1.SetActive (false);
		Collider2D[] andarCanoa = Physics2D.OverlapCircleAll (acaoPos.position, acaoDistancia, whatIsCanoa);
		for (int i = 0; i < andarCanoa.Length; i++) {
			if ((jogador.GetComponent<PlayerAtack> ().coins >= precoPassagem) && (qntPassagem >= 1)) {
				gameObject.GetComponent<AudioSource> ().PlayOneShot (somCompra,1f);
				andarCanoa [i].GetComponent <Alho> ().m_Velocidade = 250;
				qntPassagem--;
				jogador.GetComponent<PlayerAtack> ().coins = jogador.GetComponent<PlayerAtack> ().coins - precoPassagem;

				chatCanoa3.SetActive (true);
				missao01.SetActive (true);
				efeitoMissao01.SetActive (true);
				efeitoNPC01.SetActive (false);
				StartCoroutine (Missao01Delay ());
			} else {
				chatCanoa2.SetActive (true);
			}
		}
	}

	public void AbrirLoja ()
	{
		chatVendedora3.SetActive (false);
		efeitoNPC02.SetActive (false);
		Collider2D[] abrirLoja = Physics2D.OverlapCircleAll (acaoPos.position, acaoDistancia, whatIsLoja);
		for (int i = 0; i < abrirLoja.Length; i++) {
			if ((jogador.GetComponent<PlayerAtack> ().coins >= precoItem) && (estoqueAlho >= 1)) {
				gameObject.GetComponent<AudioSource> ().PlayOneShot (somCompra, 1f);
				estoqueAlho = 0;
				jogador.GetComponent<PlayerAtack> ().coins = jogador.GetComponent<PlayerAtack> ().coins - precoItem;
				item_hud.SetActive (true);
				txtAlho.SetActive (true);
				txtAlhoRestante.text = alhoRestante.ToString ();
				item = true;
				btnArremeco.sprite = btnArremecoAtivo;
				missao02.SetActive (true);
				efeitoMissao02.SetActive (true);
				StartCoroutine (Missao02Delay ());
				chatVendedora5.SetActive (true);
				efeitoArremesso.SetActive (true);
			} else if (estoqueAlho == 0) {
				chatVendedora6.SetActive (true);
			}
			 else{
				chatVendedora4.SetActive(true);
			}
		}
	}

	public void AbrirCuriosidade01 ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] curiosidade01ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade01);
			for (int i = 0; i < curiosidade01ParaAbrir.Length; i++) {
				curiosidade01.SetActive (true);
				Time.timeScale = 0;
				efeitoFragmento01.SetActive (false);
			}
		}
	}

	public void AbrirCuriosidade02 ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] curiosidade02ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade02);
			for (int i = 0; i < curiosidade02ParaAbrir.Length; i++) {
				curiosidade02.SetActive (true);
				Time.timeScale = 0;
				efeitoFragmento02.SetActive (false);
			}
		}
	}

	public void AbrirCuriosidade03 ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] curiosidade03ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade03);
			for (int i = 0; i < curiosidade03ParaAbrir.Length; i++) {
				curiosidade03.SetActive (true);
				Time.timeScale = 0;
				efeitoFragmento01.SetActive (false);
				efeitoFragmento03.SetActive (false);
			}
		}
	}

	public void fecharTodasCuriosidades ()
	{
		if (Input.GetKey (KeyCode.Return)) {
			curiosidade01.SetActive (false);
			curiosidade02.SetActive (false);
			curiosidade03.SetActive (false);
			Time.timeScale = 1;
		}
	}


	public void AbrirChatCanoa ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] npcToChat = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPC);
			for (int i = 0; i < npcToChat.Length; i++) {
				chatCanoa1.SetActive (true);
			}
		}
	}


	public void AbrirChatMensagem ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] npcToChatMensagem = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPCMensagem);
			for (int i = 0; i < npcToChatMensagem.Length; i++) {
				chatMensagem.SetActive (true);
				efeitoNPC03.SetActive (false);
			}
		}
	}

	public void AbrirChatFinal ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] npcToChatFinal = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPCFinal);
			for (int i = 0; i < npcToChatFinal.Length; i++) {
				chatFinal.SetActive (true);
				efeitoNPC04.SetActive (false);
			}
		}
	}

	public void AbrirTesteFinal ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] testeFinal = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsTesteFinal);
			for (int i = 0; i < testeFinal.Length; i++) {
				telaTesteFinal.SetActive (true);
			}
		}
	}

	public void FecharTodosChats ()
	{
		chatCanoa1.SetActive (false);
		chatCanoa2.SetActive (false);
		chatCanoa3.SetActive (false);
		chatVendedora3.SetActive (false);
		chatVendedora4.SetActive (false);
		chatVendedora5.SetActive (false);
		chatVendedora6.SetActive (false);
		chatFinal.SetActive (false);
		chatMensagem.SetActive (false);


	}

	public void chatLoja1 ()
	{
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] abrirLoja = Physics2D.OverlapCircleAll (acaoPos.position, acaoDistancia, whatIsLoja);
			for (int i = 0; i < abrirLoja.Length; i++) {
				chatVendedora1.SetActive (true);
			}
		}
	}
	public void chatLoja2 (){
		chatVendedora1.SetActive (false);
		chatVendedora2.SetActive (true);

	}
	public void chatLoja3 (){
		chatVendedora2.SetActive (false);
		chatVendedora3.SetActive (true);
	}



	public void Restart02(){
		SceneManager.LoadScene ("LoadScreenAventura02");
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
		efeitoBau.SetActive (true);
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
