using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoiScript : MonoBehaviour {
	
	Rigidbody2D rb;	
	public GameObject[] arrows;
	public GameObject mainCamera;
	public GameObject timeBar;
	public GameObject instructionScreen;
	public float jumpSpeed;
	bool inRing;
	bool corout;
	public static float timeLeft = 5.0f;
	public static float totalTime = 5.0f;
	public float flySpeed = 10.0f;
	float flyLeft;
	float flyRight;
	public static int score;
	public static int lives;
	public static int highScore;
	int ringCount;
	int randomArrow;
	float barLength;
	float barY;
	float barZ;
	int level;

	// Use this for initialization
	void Start () {
		timeLeft = totalTime;	
		inRing = false;
		corout = false;
		flyLeft = flySpeed; // starts off pushing towards the left side
		flyRight = flySpeed;
		score = 0;
		rb = GetComponent<Rigidbody2D>();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		timeBar = GameObject.FindGameObjectWithTag ("Timer");
		barLength = timeBar.transform.localScale.x;
		barY = timeBar.transform.localScale.y;
		barZ = timeBar.transform.localScale.z;
		level = 1;
		lives = 5;
		if (PlayerPrefs.GetInt ("hasPlayed") != 1) {
			GameObject go;
			go = Instantiate (instructionScreen) as GameObject;
			go.transform.SetParent (mainCamera.transform);
			go.transform.position = new Vector3 (0f, 0f, -3.84f);
			PlayerPrefs.SetInt ("hasPlayed", 1);
		}
	}
		
	public void deleteArrow(){
		Destroy (GameObject.FindGameObjectWithTag ("Arrow"));
		Debug.Log ("Arrow Destroyed");
	}

	void goodJob(){
		if (corout) {
			deleteArrow ();
			score++;
			rb.velocity = new Vector2 (0f, flySpeed);
			corout = false;
		}
	}

	void arrowPrompt(SwipeDirection dir){
			if (Swipe.Instance.IsSwiping (dir)) {
				goodJob ();
			}
			if (!Swipe.Instance.IsSwiping (dir) && !Swipe.Instance.IsSwiping (SwipeDirection.None)) {
			lives--;
			}
			timeLeft -= Time.deltaTime;	
	}

	IEnumerator coroutine() {
		corout = true;
		while (timeLeft > 0f) {
			while (GameObject.Find ("Left Arrow(Clone)") != null) {
				arrowPrompt (SwipeDirection.Left);
				yield return null;
			}
			while (GameObject.Find ("Right Arrow(Clone)") != null) {
				arrowPrompt (SwipeDirection.Right);
				yield return null;
			}
			while (GameObject.Find ("Down Arrow(Clone)") != null) {
				arrowPrompt (SwipeDirection.Down);
				yield return null;
			}
			while (GameObject.Find ("Up Arrow(Clone)") != null) {
				arrowPrompt (SwipeDirection.Up);
				yield return null;
			}

			yield return null;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		inRing = false;
	}

	//handles triggers
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("where crash");
		if (col.gameObject.tag == "Rings" ) {
			inRing = true;
			Debug.Log ("Triggered");
			rb.velocity = new Vector2 (0f, 0f);
			randomArrow = Random.Range (0, 4);
			Debug.Log (randomArrow);
			spawnRandomArrow (randomArrow);
			timeLeft = totalTime;

			StartCoroutine (coroutine ());
			Debug.Log("hit some ring thingys");
		}
		if (col.gameObject.tag == "Missed") {
			lives--;
		}	
	}
		
	// Update is called once per framed
	void FixedUpdate () {
		flyLeft = flySpeed * -1 * 30 / 100; 
		flyRight = flySpeed * 30 / 100;
		if (GameObject.FindGameObjectWithTag ("Instructions") != null) {
			if (Swipe.Instance.IsSwiping (SwipeDirection.Tap)) {
				Destroy (GameObject.FindGameObjectWithTag ("Instructions"));
			}
		}
		if (timeLeft <= 0f || lives == 0) {
			GameOver ();
		}
		if (Swipe.Instance.IsSwiping(SwipeDirection.Left) && !inRing) {
			rb.velocity = new Vector2 (flyLeft, 0.0f);
		}

		if (Swipe.Instance.IsSwiping(SwipeDirection.Right) && !inRing) {
		rb.velocity = new Vector2 (flyRight, 0.0f);
		}

		if (Swipe.Instance.IsSwiping(SwipeDirection.Tap) && !inRing) {
			rb.velocity = new Vector2 (0.0f, flySpeed);
		}
		if (score % 10 == 0 && level != 1) {
			level++;
			flySpeed = flySpeed * level;
		}
		timeBar.transform.localScale = new Vector3 (timeLeft / totalTime * barLength, barY, barZ);

	}


	// spawn random arrow
	public void spawnRandomArrow(int n){
		GameObject go;
		go = Instantiate (arrows [n]) as GameObject;
		go.transform.SetParent (mainCamera.transform);
		go.transform.position = new Vector3(0f, mainCamera.transform.position.y + 2.5f, -5f);
		Debug.Log ("Arrow Spawned");
	}


	public void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}

}
