using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour {

	public GameObject bulletPrefab = null;
	public GameObject screen = null;
	
	private float delta = 0.15f;
	public Vector4 limits = new Vector4(-8, 8, -4.3f, 4.3f);

	enum MoveDirectionX 
	{
		Left,
		Right,
		Stop
	}

	enum MoveDirectionY
	{
		Up,
		Down,
		Stop
	}
	
	private MoveDirectionX directionX = MoveDirectionX.Stop;
	private MoveDirectionY directionY = MoveDirectionY.Stop;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InputControl();
	}
	void InputControl()
	{
		Vector3 position = transform.position;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
			bullet.transform.parent = screen.transform;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
			directionY = MoveDirectionY.Down;
		if (Input.GetKeyUp(KeyCode.DownArrow))
			directionY = MoveDirectionY.Stop;
		
		if (Input.GetKeyDown(KeyCode.UpArrow))
			directionY = MoveDirectionY.Up;
		if (Input.GetKeyUp(KeyCode.UpArrow))
			directionY = MoveDirectionY.Stop;

		if (Input.GetKeyDown(KeyCode.LeftArrow))
			directionX = MoveDirectionX.Left;
		if (Input.GetKeyUp(KeyCode.LeftArrow))
			directionX = MoveDirectionX.Stop;

		if (Input.GetKeyDown(KeyCode.RightArrow))
			directionX = MoveDirectionX.Right;
		if (Input.GetKeyUp(KeyCode.RightArrow))
			directionX = MoveDirectionX.Stop;

		
		Vector3 newPosition = transform.position;
		switch(directionY)
		{
     		case MoveDirectionY.Down:
     		{
				if (position.y - delta > limits.z)
					newPosition = new Vector3(newPosition.x, newPosition.y - delta, newPosition.z);
				break;
     		}
			case MoveDirectionY.Up:
			{
				if (position.y + delta < limits.w)
					newPosition = new Vector3(newPosition.x, newPosition.y + delta, newPosition.z);
				break;
			}
		}

		switch (directionX)
		{
			case MoveDirectionX.Left:
			{
				if (position.x - delta > limits.x)
					newPosition = new Vector3(newPosition.x - delta, newPosition.y, newPosition.z);
				break;
			}
			case MoveDirectionX.Right:
			{
				if (position.x + delta < limits.y)
					newPosition = new Vector3(newPosition.x + delta, newPosition.y, newPosition.z);
				break;
			}
		}

		if (position != newPosition)
			transform.position = newPosition;
	}
}
