using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : MonoBehaviour {
	private float tempoEntreAtaque;
	public float startTempoEntreAtaque;
	public GameObject piranha;
	public Animator player;
	public Transform ataquePos;
	public float ataqueRange;
	public LayerMask whatIsPlayer;
	public LayerMask whatIsDeadZone;
	public int damage;
	public AudioClip playerHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (tempoEntreAtaque <= 0) {
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

		Collider2D[] DeadZone = Physics2D.OverlapCircleAll (ataquePos.position, ataqueRange, whatIsDeadZone);
		for (int i = 0; i < DeadZone.Length; i++) {
			Destroy (piranha);
		}

		
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (ataquePos.position, ataqueRange);
	}
}
