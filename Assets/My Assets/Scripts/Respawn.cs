using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public float RespawnTime;
	public SceneItem Spawner;

	private float timer;
	void Start()
	{
		timer = RespawnTime;
	}
	void Update () {
		if (timer > 0.0f)
						timer -= Time.deltaTime;
				else 
						Destroy (this);
	}
	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2.0f, Screen.height / 2.0f, 100, 50),timer.ToString());
	}
	void OnDestroy()
	{
		Application.LoadLevel ("GameOwerScene");
	}
}
