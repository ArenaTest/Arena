using UnityEngine;
using System.Collections;

public class ArenaSceneItem : MonoBehaviour {

	public enum ItemType
	{
		bullets,
		medcit
	}
	public ItemType Item_type;
	public int size;
	private string function;

	void Start () {

		switch (Item_type) {
			case ItemType.bullets:
				function = "AddBullets";
				break;
			case ItemType.medcit:
				function = "AddHeals";
				break;
		}
	}
	
	void OnTriggerEnter(Collider col) {
		Debug.Log ("InTrigger");
		if (col.gameObject.tag == "Player") {
						col.gameObject.SendMessage (function, size);
						Destroy(this.gameObject);	
			}
		}
}
