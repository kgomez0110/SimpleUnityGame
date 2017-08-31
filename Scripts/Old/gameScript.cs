using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : MonoBehaviour {

	static int numScreens;
	static int deleteIndex;
	public GameObject gameCamera;
	public GameObject[] background;
	float cameraYPos;
	Transform lastBackgroundPos;
	Transform spawn;

	// Use this for initialization
	void Start () {
		numScreens = 0;
		deleteIndex = 0;
		lastBackgroundPos = background [2].GetComponent<Transform> ();
		spawn = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () { 
		cameraYPos = gameCamera.transform.position.y;
		if (cameraYPos % 15.0f == 0) {
			spawn.position = new Vector3 (0.0f, lastBackgroundPos.position.y + 12.4016f, 0.0f);
			spawnBackground (spawn);
			if (numScreens % 2 != 0) {
				Destroy (background [deleteIndex]);
				deleteIndex++;
			}
			numScreens++;
		}

	}

	void spawnBackground(Transform pos){
		Instantiate (background[numScreens], pos);
		numScreens++;
	}
}
