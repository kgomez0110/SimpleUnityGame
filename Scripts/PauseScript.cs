using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	public GameObject pauseMenu;
	GameObject mainCamera;
	bool paused;
	GameObject go;
	//public Button pauseButton;

	// Use this for initialization
	void Start () {
		paused = false;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("pause button clicked");
		if (paused == false) {
			Debug.Log ("hit pause menu");
			Time.timeScale = 0.0f;
			paused = true;
			go = Instantiate (pauseMenu) as GameObject;
			go.transform.SetParent (transform);
			go.transform.position  = new Vector3 (0f, mainCamera.transform.position.y);

		}
		else if(paused == true){
			Time.timeScale = 1.0f;
			paused = false;
			Destroy(GameObject.FindGameObjectWithTag("Pause Menu"));
		}
	}
	// Update is called once per frame
	void Update () {
		
//		GameObject go;
//		if (Input.GetMouseButton(0)) {
//			//Input.GetTouch (0).phase == TouchPhase.Began) {
//			//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), -Vector2.up);
//			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	
//			RaycastHit2D hit = Physics2D.Raycast (Input.mousePosition, -Vector2.up);
//			Debug.Log ("Tap");
//			if (hit.collider != null) {
//				if (hit.collider.tag == "Pause" && paused == false) {
//					Debug.Log ("hit pause menue");
//					Time.timeScale = 0.0f;
//					paused = true;
//					go = Instantiate (pauseMenu) as GameObject;
//					go.transform.SetParent (transform);
//					go.transform.position  = new Vector3 (0f, 0f);
//
//				}
//				else if(hit.collider.tag == "Pause" && paused == true){
//					Time.timeScale = 1.0f;
//					paused = false;
//					Destroy(GameObject.FindGameObjectWithTag("Pause Menu"));
//				}
//			}
//		}
	}
}
