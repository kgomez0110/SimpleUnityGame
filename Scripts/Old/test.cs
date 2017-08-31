using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	
	float timeLeft;
	float totalTime = 100f;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
	//	cubePosition = cube.GetComponent<Transform> ();
		//Debug.Log (cubePosition.position.x);
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (-3f, 0f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
	void OnCollisionEnter(Collision col) {
		Debug.Log ("colliding");

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("triggered");
			timeLeft = totalTime;
			rb.velocity = new Vector3 (0f, 0f, 0f);
			while (timeLeft > 0) {
				if (whichKey () == 1) {
					Debug.Log ("true");
					break;
				}
				Debug.Log (timeLeft);
				timeLeft -= Time.deltaTime;
			}
		}
	}

	int whichKey(){
		if (Input.GetKey ("up")) {
			Debug.Log ("up");
			return 1;
		}
		if (Input.GetKey ("down")) {
			Debug.Log ("down");
			return 2;
		}
		if (Input.GetKey ("left")) {
			Debug.Log ("left");
			return 3;
		}
		if (Input.GetKey ("right")) {
			Debug.Log ("right");
			return 4;
		}
		return 0;
	}
}
