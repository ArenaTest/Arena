using UnityEngine;
using System.Collections;

public class PlayerSuncTut : MonoBehaviour {

	private Vector3 lastPos;
	private Quaternion lastRot;
	private Transform myTransform;
	// Use this for initialization
	void Start () {
		if(networkView.isMine)
		{
			myTransform = transform;
		}
		{
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(myTransform.position,lastPos)>=0.05f)
		{
			lastPos = myTransform.position;
			networkView.RPC("UpdateMovement", RPCMode.OthersBuffered, myTransform.position, myTransform.rotation);
		}
		if(Quaternion.Angle(myTransform.rotation,lastRot)>=1)
		{
			lastRot = myTransform.rotation;
			networkView.RPC("UpdateMovement", RPCMode.OthersBuffered, myTransform.position, myTransform.rotation);
		}
	}
	[RPC]
	void UpdateMovement(Vector3 newPosition,Quaternion newRotation)
	{
		transform.position = newPosition;
		transform.rotation = newRotation;
	}
	/*void UpdateRotation(Quaternion newRotation)
	{
		transform.rotation = newRotation;
	}*/
}
