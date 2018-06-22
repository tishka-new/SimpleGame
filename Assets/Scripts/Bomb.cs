using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	float speed = 4.0f;
	float xLimit = -8.0f;
	public int count = 2;
	public GameObject restartButton;
   void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.GetComponent<Bullet>())
		{
			count --;
			if (count <= 0)
				Destroy(gameObject);
			Destroy(col.gameObject);
		}
		if (col.gameObject.GetComponent<HeroControl>())
		{
			Destroy(col.gameObject);
			if (gameObject.GetComponentInParent<SceneController>())
			{
				gameObject.GetComponentInParent<SceneController>().PluhAction();
			}
		}

    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		Vector3 newPosition = new Vector3(position.x - Time.deltaTime * speed, position.y, position.z);
		transform.position = newPosition;
		if (newPosition.x < xLimit)
			Destroy(gameObject);
	}
}
