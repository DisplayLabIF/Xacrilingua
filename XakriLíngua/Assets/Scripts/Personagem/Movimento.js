#pragma strict
import UnityStandardAssets.CrossPlatformInput;

var animador: Animator;
var rb2D: Rigidbody2D;
var colisao: RaycastHit2D;
var caixaColisao: BoxCollider2D;
var colisaoNoAr: boolean;
var andar: AudioClip;
var audioSource: AudioSource;

function Start () {
animador.SetBool("noChao",true);
animador.SetBool("seMovendo",false);
}

function Update () {
	
	Move(CrossPlatformInputManager.GetAxis("Horizontal")*300,CrossPlatformInputManager.GetAxis("Horizontal")*550);
}

function Move(direcao: int, velocidade:int){

	if(!colisaoNoAr){
		if(direcao>0)
			transform.rotation.eulerAngles.y = 0;
		if(direcao<0)
			transform.rotation.eulerAngles.y = 180;

		rb2D.velocity.x = velocidade;

		if(velocidade !=0){
			animador.SetBool("seMovendo",true);
		}
		else
		animador.SetBool("seMovendo",false);
	}else{
		colisaoNoAr = false;
	}
}

function OnCollisionStay2D(outro: Collision2D){
	if(outro.gameObject.CompareTag("parede")){
		colisaoNoAr = true;
		animador.SetBool("seMovendo",false);
		animador.SetBool("noChao", true);
	}
	if(outro.gameObject.CompareTag("enemy")){
		colisaoNoAr = false;
		animador.SetBool("noChao",true);
	}

	
}

function OnCollisionExit2D(outro: Collision2D){
		colisaoNoAr = false;
		animador.SetBool("seMovendo",true);
}


