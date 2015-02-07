using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay(Collider coll)
	{
		if (coll.tag == "Player") {
			Debug.Log("DAMAGE");
			coll.SendMessageUpwards("ApplyDamage", 100, SendMessageOptions.DontRequireReceiver);
		}
	}
}
