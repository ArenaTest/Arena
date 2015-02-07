using UnityEngine;
using System.Collections;

public class WeaponSlotChange : MonoBehaviour {
	public GameObject Weapon_slot_1;
	public GameObject Weapon_slot_2;

	// Use this for initialization	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("WSlot1"))
		   {
			Weapon_slot_1.SetActive(true);
			Weapon_slot_2.SetActive(false);
		}
		if(Input.GetButtonDown("WSlot2"))
		   {
			Weapon_slot_2.SetActive(true);
			Weapon_slot_1.SetActive(false);
		}
	
	}
}
