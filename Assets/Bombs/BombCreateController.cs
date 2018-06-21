using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreateController : MonoBehaviour {

	private float createTime;
	public GameObject[] prefabs;
	public GameObject screen = null;

	public Vector3 startPosition;
	private Vector2 limits = new Vector2 (-4.0f, 4.0f);

	// Use this for initialization
	void Start () {
		GenerateRandomTime();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > createTime)
		{
			GenerateRandomTime();
			float yPosition = Random.Range(-4, 4);
			GameObject newBomb = Instantiate(prefabs[Random.Range(0, prefabs.Length)], 
			new Vector3(transform.position.x, yPosition, 0), Quaternion.identity);
			newBomb.transform.parent = transform;
			newBomb.transform.localScale = new Vector3(1,1,1);
		}
	}

	void GenerateRandomTime()
	{
		createTime = Time.time + Random.Range(1.3f, 2.5f);
	}
}
