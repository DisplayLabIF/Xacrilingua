using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alho : MonoBehaviour {

	// Use this for initialization
	public float m_Velocidade;
	public Transform m_position;
	public float x_Position,y_Position;

	int m_Randomica;
	void Start () {
		m_position.position = new Vector2 (x_Position, y_Position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector2.MoveTowards (transform.position, m_position.position, m_Velocidade * Time.deltaTime);

	}
}
