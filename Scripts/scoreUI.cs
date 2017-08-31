using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUI : MonoBehaviour {

	// Use this for initialization
	Text currentScore;
	Text currentLives;
	public GameObject livesObject;

	void Start () {
		currentScore = GetComponent<Text> ();
		currentLives = livesObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentScore.text = BoiScript.score.ToString ();
		currentLives.text = BoiScript.lives.ToString ();
	}
}
