﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public GameObject restart;
	
	public AudioSource pluh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartScene()
	{
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
	}

	public void PluhAction()
	{
		restart.SetActive(true);
		pluh.Play();
	}
}
