using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int scoreCount;
	private GameObject owerObject;
	// Use this for initialization
	void Start () {
		scoreCount = 0;
		DontDestroyOnLoad (this);
	}
	void Update()
	{
		if (Application.loadedLevelName == "GameOwerScene") {
			owerObject = GameObject.FindGameObjectWithTag("MainCamera");
			owerObject.SendMessage("SetScore", scoreCount);
			Destroy(this);
		}

	}

	void AddScore (){
		scoreCount++;
	}
	// Update is called once per frame
	void OnGUI() {
		GUI.Label (new Rect (0, 0, 100, 20), "Score: " + scoreCount);
	}
}
