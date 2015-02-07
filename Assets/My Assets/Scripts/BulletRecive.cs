using UnityEngine;
using System.Collections;

public class BulletRecive : MonoBehaviour {
	public GameObject Weapon;

	// Use this for initialization
	void AddBullets (int size) {
		Weapon.SendMessage ("AddBullets", size);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
