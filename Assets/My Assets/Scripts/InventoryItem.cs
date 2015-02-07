using UnityEngine;
using System.Collections.Generic;
public enum itemType
{
	Weapon,
	Leg_Armor,
	Hand_Armor,
	Torso_Armor,
	On_Head,
	Backpack,
	Food,
	Not_Usable,
	Medkit
}

public class InventoryItem : MonoBehaviour
{
	// название вещи
	public string itemName;
	public itemType type;
	public List<float> Properties = new List<float>();
	// текстура для инвентаря
	public Texture2D inventoryTexture;
	// префаб для сброса вещи
	public GameObject prefabToDrop;
	// префаб для одевания
	public GameObject prefabToEquip;
};


