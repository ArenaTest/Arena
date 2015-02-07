using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RandomDrop : MonoBehaviour {

	public List<GameObject> Items;
	public float Chanse;
	
	void DropLoot () 
	{
		if (Random.Range (0f, 10f) > (10 - Chanse)) 
		{
			Instantiate (Items [Random.Range (0, Items.Count)], transform.position, transform.rotation);	
		}
	}
}
