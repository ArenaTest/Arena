using UnityEngine;

// объект сцены, который можно подобрать
public class SceneItem : MonoBehaviour
{
	// префаб для инвентаря
	public InventoryItem prefab;
	private bool canGet = false;
	private GameObject player;
	void Update ()
	{
				player = GameObject.FindWithTag ("Player");
	}
	void OnMouseEnter()
	{
		canGet = true;
		Debug.Log ("Can Get");
	}
	void OnMouseExit()
	{
		canGet = false;
	}
	void get()
	{
		player.SendMessage("Equip", this);
	}
}