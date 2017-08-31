using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class replayScript : MonoBehaviour {

	public GameObject scoreText;
	public GameObject highScoreText;
	Text currentScore;
	Text highScore;
	int numberHigh;

	// Use this for initialization
	void Start () {
		numberHigh = PlayerPrefs.GetInt ("highScore", numberHigh);

		if (BoiScript.score > numberHigh) {
			numberHigh = BoiScript.score;
			PlayerPrefs.SetInt ("highScore", numberHigh);
		}
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (TaskOnClick);
		currentScore = scoreText.GetComponent<Text>();
		currentScore.text = BoiScript.score.ToString ();
		highScore = highScoreText.GetComponent<Text>();
		highScore.text = numberHigh.ToString ();

			
	}

	void TaskOnClick(){
		Debug.Log ("Replay");
		SceneManager.LoadScene ("main");
		//fadeAndLoad ();
	}

}
