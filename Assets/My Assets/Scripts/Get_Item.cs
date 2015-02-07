using UnityEngine;
using System.Collections;

public class Get_Item : MonoBehaviour {
	private GameObject item;
	private Ray ray;
	private RaycastHit hit;
	private bool itsItem;
	void Start()
	{
		itsItem = false;
		ray = gameObject.camera.ScreenPointToRay(new Vector3(Screen.width / 2,Screen.height / 2, 0));
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd,out hit, 3) == true){

				item = hit.collider.gameObject;
			if(item.GetComponent<SceneItem>()== true)
			{
				itsItem = true;
				if(Input.GetButtonDown("Use"))
				{
					item.SendMessage("get");
				}
			}
			else
			{
				itsItem = false;
			}
		}
	}

	void OnGUI()
	{
		if(itsItem)
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100, 20), "Press Use to get");
	}
}
