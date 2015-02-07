using UnityEngine;
using System.Collections;

public class Tornado: MonoBehaviour {
	public float UpForse = 25;
	public float HorizontalForseCoef = 50;
	void OnTriggerStay (Collider coll) 
	{
		if (coll.tag == "Player") {
			Debug.Log("Player in");
			coll.SendMessageUpwards("MoveX",1-Mathf.Pow((gameObject.transform.position.z),2)-coll.transform.position.x, SendMessageOptions.DontRequireReceiver);
			//coll.SendMessageUpwards("MoveY",UpForse/20, SendMessageOptions.DontRequireReceiver);
			                        coll.SendMessageUpwards("MoveZ",1-Mathf.Pow((gameObject.transform.position.x),2)-coll.transform.position.z, SendMessageOptions.DontRequireReceiver);
		}
		if (coll.attachedRigidbody) {
			coll.attachedRigidbody.AddForce(new Vector3((gameObject.transform.position.x-coll.transform.position.x)*HorizontalForseCoef,UpForse,(gameObject.transform.position.z-coll.transform.position.z)*HorizontalForseCoef));

		}
	}
	void OnTriggerExit (Collider coll)
	{
		if (coll.tag == "Player") {
			//coll.SendMessageUpwards("MoveZero", SendMessageOptions.DontRequireReceiver);
			Debug.Log("Player out");
		}

	}
}
