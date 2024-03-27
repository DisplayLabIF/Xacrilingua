using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aventura01 : MonoBehaviour {

	public float tempoEntreAtaque;
	public float acaoDistancia;
	public float ataqueRange;

	public GameObject Chat01;
	public GameObject Chat02;
	public GameObject Chat03;
	public GameObject Chat04;
	public GameObject Chat05;
	public GameObject item_hud;
	public GameObject bau;
	public GameObject itemBau;
	public GameObject smokePuff;
	public GameObject jogador;
	public GameObject infoMissao;
	public GameObject missao01;
	public GameObject missao02;
	public GameObject missao03;
	public GameObject missao04;
	public GameObject lblMissao01;
	public GameObject lblMissao02;
	public GameObject lblMissao03;
	public GameObject lblMissao04;
	public int missao01Status;
	public int missao02Status;
	public int missao03Status;
	public int missao04Status;

	public LayerMask whatIsNPC;
	public LayerMask whatIsLacraia;
	public LayerMask whatIsBau;
	public LayerMask whatIsCuriosidade01;
	public LayerMask whatIsCuriosidade02;
	public LayerMask whatIsCuriosidade03;
	public LayerMask whatIsTesteFinal;
	public GameObject telaTesteFinal;

	public GameObject curiosidade01;
	public GameObject curiosidade02;
	public GameObject curiosidade03;
	public GameObject efeitoArremesso;
	public GameObject efeitoMissao01;
	public GameObject efeitoMissao02;
	public GameObject efeitoMissao03;
	public GameObject efeitoMissao04;
	public GameObject efeitoFragmento01;
	public GameObject efeitoFragmento02;
	public GameObject efeitoFragmento03;
	public GameObject efeitoNPC01;
	public GameObject efeitoBau;
	public Transform ataquePos;
	public Transform chatPos;
	public Transform acaoPos;
	public Transform firePoint;
	public Transform detectorDeChao;
	public Transform myTransform;


	public Text txtMoedas;

	public int lacraiasMortas;
	private int chatCheck01;
	private int chatCheck02;
	private int damage = 1;
	public int coins;

	private bool item;

	public AudioClip somCompletar;
	public AudioClip somSmoke;
	public AudioClip somItem;
	public AudioClip somQueimarAlho;

	public Animator abrirBau;
	public Animator smokePuff2;
	public Animator animador;
	public GameObject rio;
	public Image btnArremeco;
	public Sprite btnArremecoNull;
	public Sprite btnArremecoAtivo;
	private int verificadorMoedas;
	private int duplo = 1;
	public float cooldown;
	public float coolDownTimer;

	// Use this for initialization
	void Start () {
		jogador.GetComponent <PlayerAtack> ().verificador01 = 1;
		rio.GetComponent<Rio> ().verificador01 = 1;
		lblMissao01.SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		txtMoedas.text = coins.ToString ();
		lacraiasRestante ();

		if (jogador.GetComponent<PlayerAtack> ().coins == 20) {
			verificadorMoedas = 1;
		}

	
		if (verificadorMoedas == 1) {
			missao01.SetActive (true);
			efeitoMissao01.SetActive (true);
			StartCoroutine (Missao01Delay ());
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
			lblMissao04.SetActive (true);
		}

		if (missao04Status == 1) {
			efeitoNPC01.SetActive (true);
			lblMissao04.SetActive (false);
			missao04.SetActive (false);
		}

		if (coolDownTimer > 0) {
			coolDownTimer -= Time.deltaTime;
		}

		if (coolDownTimer < 0) {
			coolDownTimer = 0;
		}

		if ((Input.GetKey (KeyCode.C)) && (coolDownTimer == 0)) {
			coolDownTimer = cooldown;
			QueimarAlho ();
		}

		AbrirCuriosidade01 ();
		AbrirCuriosidade02 ();
		AbrirCuriosidade03 ();
		fecharTodasCuriosidades ();
		AbrirTesteFinal ();
		NPC ();
		AbrirBau();
	}

	public void AbrirCuriosidade01(){
		if(Input.GetKey (KeyCode.Z)){
			Collider2D[] curiosidade01ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade01);
			for (int i = 0; i < curiosidade01ParaAbrir.Length; i++) {
					curiosidade01.SetActive (true);
					efeitoFragmento01.SetActive (false);
					Time.timeScale = 0;
			}
		}
	}

	public void AbrirCuriosidade02 (){
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] curiosidade02ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade02);
			for (int i = 0; i < curiosidade02ParaAbrir.Length; i++) {
				curiosidade02.SetActive (true);
				efeitoFragmento02.SetActive (false);
				Time.timeScale = 0;
			}
		}
	}

	public void AbrirCuriosidade03 (){
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] curiosidade03ParaAbrir = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsCuriosidade03);
			for (int i = 0; i < curiosidade03ParaAbrir.Length; i++) {
				curiosidade03.SetActive (true);
				efeitoFragmento03.SetActive (false);
				Time.timeScale = 0;
			}
		}
	}

	public void fecharTodasCuriosidades (){
		if (Input.GetKey (KeyCode.Return)) {
			curiosidade01.SetActive (false);
			curiosidade02.SetActive (false);
			curiosidade03.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void AbrirTesteFinal (){
		if (Input.GetKey (KeyCode.Z)) {
			Collider2D[] testeFinal = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsTesteFinal);
			for (int i = 0; i < testeFinal.Length; i++) {
				telaTesteFinal.SetActive (true);
			}
		}
	}

	//METODO PARA QUEIMAR O ALHO
	public void QueimarAlho (){
		if (item == true) {
			animador.SetBool ("queimar", true);
			jogador.GetComponent<AudioSource> ().PlayOneShot (somQueimarAlho);
			Collider2D[] lacraiaToDamage = Physics2D.OverlapCircleAll (ataquePos.position, ataqueRange, whatIsLacraia);
			for (int i = 0; i < lacraiaToDamage.Length; i++) {
					lacraiaToDamage [i].GetComponent <Enemy> ().health -= damage;
			}
			StartCoroutine (Pausa2 ());
		}
	}

	//METODO PARA CONVERSAR COM O NPC
	public void NPC ()
	{	
		if (Input.GetKey (KeyCode.Z)) {
			if ((lacraiasMortas >= 6) && (jogador.GetComponent<PlayerAtack> ().coins >= 20)) {
				Collider2D[] npcToChat = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPC);
				for (int i = 0; i < npcToChat.Length; i++) {
					Chat05.SetActive (true);
					missao04.SetActive (true);
					efeitoMissao04.SetActive (true);
					efeitoNPC01.SetActive (false);
					StartCoroutine (Missao04Delay ());
				}
			} else {
				if (chatCheck01 != 1) {
					if (Input.GetKey (KeyCode.Z)) {
						Collider2D[] npcToChat = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPC);
						for (int i = 0; i < npcToChat.Length; i++) {
							Chat01.SetActive (true);
							efeitoNPC01.SetActive (false);
						}
					}
				} else {
					if (Input.GetKey (KeyCode.Z)) {
						Collider2D[] npcToChat = Physics2D.OverlapCircleAll (chatPos.position, acaoDistancia, whatIsNPC);
						for (int i = 0; i < npcToChat.Length; i++) {
							Chat04.SetActive (true);
							efeitoNPC01.SetActive (false);
						}
					}
				}
			}
		}
	}

	public void lacraiasRestante ()
	{
		if (lacraiasMortas == 6) {
			missao03.SetActive (true);
			efeitoMissao03.SetActive (true);
			StartCoroutine (Missao03Delay ());
		}
	}

	//METODOS PARA ABRIR AS CAIXAS DE DIÁLOGOS
	public void Dialogo01()	{
		
		Chat01.SetActive (false);
		Chat02.SetActive (true);
	}
	//METODOS PARA ABRIR AS CAIXAS DE DIÁLOGOS
	public void Dialogo02()	{
		Chat02.SetActive (false);
		Chat03.SetActive (true);
	}
	//METODOS PARA ABRIR AS CAIXAS DE DIÁLOGOS
	public void Dialogo03()	{
		Chat03.SetActive (false);
		item_hud.SetActive (true);
		item = true;
		btnArremeco.sprite = btnArremecoAtivo;
		efeitoArremesso.SetActive (true);
		missao02.SetActive (true);
		efeitoMissao02.SetActive (true);
		StartCoroutine (Missao02Delay ());
		chatCheck01 = 1;
	}

	//METODO PARA FECHAR OS CHATS
	public void FecharChats ()
	{
		Chat01.SetActive (false);
		Chat02.SetActive (false);
		Chat03.SetActive (false);
		Chat04.SetActive (false);
		Chat05.SetActive (false);
	}

	//METODO PARA APARECER O BAÚ DE RECOMPENSA
	public void AparecerBau()
	{
		if (chatCheck02 != 1) {
			Chat05.SetActive (false);
			smokePuff.SetActive (true);
			smokePuff2.SetBool ("explodir", true);
			efeitoMissao04.SetActive (true);
			gameObject.GetComponent<AudioSource> ().PlayOneShot (somSmoke);
			StartCoroutine (Smoke ());
			chatCheck02 = 1;
			efeitoNPC01.SetActive (false);
		} else {
			Chat05.SetActive (false);
		}
	}

	//MÉTODO PARA ABRIR BAÚ
	public void AbrirBau(){
		if(Input.GetKey (KeyCode.Z)){
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

	//MÉTODO PARA RESTARTAR
	public void Restart01(){
		SceneManager.LoadScene ("LoadScreenAventura01");
	}
	//MÉTODO PARA VOLTAR AO MENU PRINCIPAL
	public void MenuPrincipal (){
		SceneManager.LoadScene ("LoadScreenMenuAventura");
	}

	//DELAYS PARA EXECUÇÃO
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

	IEnumerator Missao04Delay(){
		yield return new WaitForSeconds (2);
		missao04Status = 1;
		efeitoMissao04.SetActive (false);
	}

	IEnumerator Pausa2(){
		yield return new WaitForSeconds (1);
		animador.SetBool ("queimar", false);
	}

}

