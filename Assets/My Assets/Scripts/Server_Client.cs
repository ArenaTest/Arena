using UnityEngine;
using System.Collections;

public class Server_Client : MonoBehaviour {

	public GameObject Player;
	public Transform SpawnPlace;
	public GameObject Spawner;
	private string ip = "127.0.0.1";
	private string port = "25000";
	private bool showGUI = true;
	private GameObject player0;

	void Start()
	{

	}

	void OnGUI (){
		if (showGUI) {
						ip = GUI.TextField (new Rect (Screen.width / 2 - 100, Screen.height / 2, 100, 25), ip);
						port = GUI.TextField (new Rect (Screen.width / 2, Screen.height / 2, 100, 25), port);
						if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 25, 200, 25), "Create server")) {
								Network.InitializeServer (5, int.Parse (port), true);
						}
						if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 25), "Connect to server")) {
								Network.Connect (ip, int.Parse (port));
						}
				}
		//GUI.Label (new Rect (Screen.width - 100, 0, 100, 25), Network.connections.ToString ());
	}
	void OnServerInitialized()
	{
		showGUI = false;
		player0 = (GameObject)Network.Instantiate(Player,SpawnPlace.transform.position,SpawnPlace.transform.rotation,0);
		player0.transform.GetComponentInChildren<Camera> ().camera.enabled = true;
		player0.transform.GetComponentInChildren<AudioListener> ().enabled = true;
		player0.GetComponent<Hp> ().Spawner = Spawner;
	}
	void OnConnectedToServer()
	{
		showGUI = false;
		player0 = (GameObject)Network.Instantiate(Player,SpawnPlace.transform.position,SpawnPlace.transform.rotation,0);
		player0.transform.GetComponentInChildren<Camera> ().camera.enabled = true;
		player0.transform.GetComponentInChildren<AudioListener> ().enabled = true;
		player0.GetComponent<Hp> ().Spawner = Spawner;
	}
	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		Network.Destroy (player0.gameObject);
	}
}
