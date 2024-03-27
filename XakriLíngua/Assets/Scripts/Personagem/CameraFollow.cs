using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

public float speed = 0.15f;
private Transform target;
public bool maxMin;
public float xMin;
public float yMin;
public float xMax;
public float yMax;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, speed) + new Vector3 (0, 0, -20*target.position.z);
			if (maxMin) {
				transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y,yMin, yMax), -20*target.position.z);
			}
		}
		
	}
}
