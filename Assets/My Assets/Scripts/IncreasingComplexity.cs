using UnityEngine;
using System.Collections;

public class IncreasingComplexity: MonoBehaviour {
	public SpawnOnCount SpawnScript;
	private int count;
	// Use this for initialization
	void Start () {
		count = SpawnScript.MaxOnScene;
	}
	
	// Update is called once per frame
	void Update () {
		if (SpawnScript.complexityFlag){
			SpawnScript.MaxOnScene++;
			SpawnScript.complexityFlag = false;
		}
	
	}
}
