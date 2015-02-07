using UnityEngine;
using System.Collections;

public class GameOwer : MonoBehaviour {
	private int score = 0;
	// Use this for initialization
	void Start()
	{
		Screen.showCursor = true;
		Screen.lockCursor = false;
//		score = GameObject.FindGameObjectWithTag ("Score").GetComponentInChildren ().scoreCount;
	}
	void OnGUI() {
		GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 50), "Game over\n" + "Your score - " + score.ToString());
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 50, 100, 50), "Try again")) {
			Application.LoadLevel("Arena");		
		}
		if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 2) + 100, 100, 50), "Exit")) {
			Application.Quit();		
		}
	}
	
	// Update is called once per frame
	void SetScore (int playerScore) {
		score = playerScore;
	}
}
