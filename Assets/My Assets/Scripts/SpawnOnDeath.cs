using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnOnDeath : MonoBehaviour {

	public GameObject obj;
	public List<Transform> spawnPoints;
	public float RespawnTime;
	private bool spawnFlag = false;
	private float timer = 0.0f;

	void TimeStart()
	{
		spawnFlag = true;
		timer = RespawnTime;
	}
	/*void Update () {
		if (spawnFlag) {
						if (timer > 0.0f)
								timer -= Time.deltaTime;
						else {
								spawnFlag = false;
								Spawn ();
						}
				}
	}*/

	void Spawn() 
	{ 

			//GameObject obj = enemyPrefabs[Random.Range(0, enemyPrefabs.s)]; // Randomize the different enemies to instantiate.
			Transform pos = spawnPoints[Random.Range (0, spawnPoints.Count)];//[Random.Range(0, spawnPoints.Length)];  // Randomize the spawnPoints to instantiate enemy at next.
			obj.GetComponent<Hp> ().Spawner = this.gameObject;
			GameObject player0 = (GameObject)Network.Instantiate(obj, pos.position, pos.rotation,0);
			player0.transform.GetComponentInChildren<Camera> ().camera.enabled = true;
			player0.transform.GetComponentInChildren<AudioListener> ().enabled = true;

			
	} 
}