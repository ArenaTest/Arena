using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour {
	public float MaxHeals = 100.0f;
	// Use this for initialization
	public GameObject Spawner;
	public GameObject DestroyedObject;
	public enum SpawnType
		{
			LoadScene,
			SpawnOnDeath,
			SpawnOnCount,
			Waves
		}
	public SpawnType _spawnType;
	public bool CanDropLoot = false;
	private float heals;
	void Start()
	{
		if(networkView.isMine)
			heals = MaxHeals;
	}
	public void ApplyDamage(float damage)
	{

		//if (networkView.isMine) {
						if (heals > 0.0f)
			{
								heals -= damage;
			}
				else //if (heals <= 0.0f) {
		{
								heals = 0.0f;
//			Instantiate(DestroyedObject,transform.position,transform.rotation);
//			DestroyedObject.GetComponent<Respawn>().Spawner = Spawner;
								if (Spawner != null) {
										if (_spawnType == SpawnType.SpawnOnDeath || _spawnType == SpawnType.SpawnOnCount) {
												Spawner.SendMessage ("Spawn");
										} else
			if (_spawnType == SpawnType.Waves) {
												Spawner.SendMessage ("OnDeath");
										}
										if (_spawnType == SpawnType.LoadScene) {
												Network.Instantiate (DestroyedObject, transform.position, transform.rotation,3);
												//Application.LoadLevel("GameOwerScene");
										}
										if (CanDropLoot) {
												this.SendMessage ("DropLoot");
										}
								}
								Network.Destroy (gameObject);
						}
				//}
		}
	public void AddHeals(int addingHeals)
	{
		if (networkView.isMine) {
						if (heals > 0 && heals + addingHeals <= MaxHeals)
								heals += addingHeals;
						else if (heals + addingHeals > MaxHeals)
								heals = MaxHeals;
				}
	}

	void OnGUI ()
	{
		if(gameObject.tag == "Player" && networkView.isMine)
		GUI.Box (new Rect (0, Screen.height - 50, 100, 20), "Hp:" + heals);
		//if(death) GUI.Box (new Rect (Screen.width/2 -50 , Screen.height/2 - 50, 100, 50), "You are dead");
	}

}
