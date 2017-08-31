using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject[] prefabs;
	public GameObject[] rings;
	int numBackgrounds = 4;
	public float length = 12f;
	float spawnY = 0.0f;
	float safeZone = 12.0f;
	int randomNumber;
	Transform playerTransform;

	List<GameObject> activeBackgrounds;
	List<GameObject> activeRings;

	// Use this for initialization
	void Start () {
		activeBackgrounds = new List<GameObject> ();
		activeRings = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		randomNumber = Random.Range (0, 2);
		for (int ii = 0; ii < numBackgrounds; ii++) {
			spawnRings (randomNumber);
			spawnBackground ();
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.y - safeZone > (spawnY - numBackgrounds * length)) {
			randomNumber = Random.Range (0, 2);
			spawnBackground ();
			spawnRings (randomNumber);
			deleteBackground ();
		}
	}

	void spawnBackground(int index = -1){
		GameObject go;
		go = Instantiate (prefabs [0]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.up * spawnY;
		spawnY += length;
		activeBackgrounds.Add (go);
	}

	void deleteBackground(){
		Destroy (activeBackgrounds [0]);
		activeBackgrounds.RemoveAt (0);
	}

	void spawnRings(int index){
		GameObject go;
		go = Instantiate (rings [index]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = new Vector3 (Random.Range (-1.5f, 1.5f), spawnY + Random.Range (0, length));
		activeRings.Add (go);
	}

//	void deleteRing(){
//		Destroy (activeRings [0]);
//		activeRings.RemoveAt (0);
//	}
//
}
