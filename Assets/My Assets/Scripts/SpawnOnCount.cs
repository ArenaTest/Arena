using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnOnCount : MonoBehaviour
{
	public List<GameObject> Enemies;
	public List<Transform> SpawnPoints;
	public int MaxOnScene;
	private int countOfEnemies;
	private GameObject score;
	public bool complexityFlag;
	//private bool endOfStart = false;

	void Start()
	{
		score = GameObject.FindGameObjectWithTag ("Score");
		countOfEnemies = 0;
		complexityFlag = false;
		OnStart();
	}

	void Update()
	{
		if (countOfEnemies < MaxOnScene /*&& endOfStart*/) {
			AddEnemies();
		}
	}

	void Spawn()
	{
		countOfEnemies--;
		score.SendMessage ("AddScore");
		complexityFlag = true;
	}

	void OnStart()
	{
		for (; countOfEnemies < MaxOnScene; countOfEnemies++) 
		{
			//yield WaitForSeconds(Random.Range(yieldTimeMin, yieldTimeMax));
			GameObject obj = Enemies[Random.Range(0,Enemies.Count)];
			Transform pos = SpawnPoints[Random.Range (0, SpawnPoints.Count)];
			obj.GetComponent<Hp> ().Spawner = this.gameObject;
			Instantiate(obj, pos.position, pos.rotation);
		}
	}
	void AddEnemies()
	{
		for (; countOfEnemies < MaxOnScene; countOfEnemies++) {

			GameObject obj = Enemies[Random.Range(0,Enemies.Count)];
			Transform pos = SpawnPoints[Random.Range (0, SpawnPoints.Count)];
			obj.GetComponent<Hp> ().Spawner = this.gameObject;
			Instantiate(obj, pos.position, pos.rotation);
		}
	}
}

