using UnityEngine;
using System.Collections;

public class DeathSands : MonoBehaviour {
	private bool flag = true;
	void OnTriggerStay (Collider coll) {
		if (flag) 
		{
			coll.gameObject.transform.Translate (0.0f, -0.1f * Time.deltaTime, 0.0f);
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		flag = false;
	}
	void OnCollisionExit(Collision coll)
	{
		flag = true;
	}
}
