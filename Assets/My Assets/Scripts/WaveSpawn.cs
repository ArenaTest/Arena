using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawn : MonoBehaviour
{
		
		public int waveSize;
		public float SpawnTime;
		public float TimeBetweenWaves;
	public List<GameObject> Enemies;
	public List<Transform> SpawnPoints;
	private bool canSpawn = false;
	private bool endWave = false;
	private int enemyKilled = 0;
		private int spawnCount = 0;
		private int waveCount = 1;
		private float _timer;
		
		private GameObject score;
	
	void Start()
	{
		score = GameObject.FindGameObjectWithTag ("Score");
	}
		void Update ()
		{
			if (!endWave)
				{
						if (spawnCount < waveSize) {
				
								if (_timer < SpawnTime) {
										_timer += Time.deltaTime; 
								} else {
										_timer = 0;
										AddEnemies ();
								}
						}
				}
				else
				{
					/*if(_timer < TimeBetweenWaves){
							_timer += Time.deltaTime;
						}else{*/
							OnWaveEnd();
						/*}*/
				}
		}

		void OnDeath ()
		{
			score.SendMessage ("AddScore");
			enemyKilled++;
		if (enemyKilled == waveSize)
						endWave = true;
		}

		void OnWaveEnd ()
		{
			endWave = false;
			waveCount++;
			enemyKilled = 0;
			spawnCount = 0;
			waveSize = waveSize * 2;
		}
		void AddEnemies()
		{
			GameObject obj = Enemies [Random.Range (0, Enemies.Count)];
			Transform pos = SpawnPoints [Random.Range (0, SpawnPoints.Count)];
			obj.GetComponent<Hp> ().Spawner = this.gameObject;
			Instantiate (obj, pos.position, pos.rotation);
			spawnCount++;
		}
		
		void OnGUI()
		{
			GUI.Label (new Rect (0, 50, 120, 60), "Wave" + waveCount.ToString () + "\n" + enemyKilled.ToString () + " of " + waveSize.ToString ()); 
		}
}

