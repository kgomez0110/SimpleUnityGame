using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	void TaskOnClick(){
		SceneManager.LoadScene ("main");
	}
}
