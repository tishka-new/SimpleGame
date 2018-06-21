using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 100f;
	public float maxXPosition = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		transform.position = new Vector3(position.x + Time.deltaTime * speed, position.y, position.z);
		if (transform.position.x > maxXPosition)
			Destroy(gameObject);
	}
}
