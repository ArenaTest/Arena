using System.Collections.Generic;
using UnityEngine;

// инвентарь
public class Inventory : MonoBehaviour
{
		// вещи инвентаря
		private List<InventoryItem>items = new List<InventoryItem> ();
		// надетые вещи
		//public List<InventoryItem> equipped = new List<InventoryItem>();
		public InventoryItem[] equipped;
		// отображать ли инвентарь
		public bool showInventory;
		public GameObject weaponSlot_1;
		public GameObject weaponSlot_2;
		// вспомогательные переменные
		private bool toSlot1 = false, toSlot2 = false;
		private Vector2 _inventoryScroll;
		private Vector2 _inventoryScroll2;
		private InventoryItem _itemToDrop = null;
		private InventoryItem _itemToEquip = null;

		void Start ()
		{
				equipped = new InventoryItem[7]{null,null,null,null,null,null,null};
		}

		public void Update ()
		{
				if (Input.GetButtonDown ("Inventory")) {
						showInventory = !showInventory;	
				}
				// если нужно выбросить вещь
				if (_itemToDrop != null) {
						// удаляем вещь из инвентаря
						items.Remove (_itemToDrop);
						// создаем в сцене эту вещь на месте, где стоит игрок
						Instantiate (_itemToDrop.prefabToDrop, transform.position, transform.rotation);
						_itemToDrop = null;
				}
		
				// если нужно одеть
				if (_itemToEquip != null) {
						switch (_itemToEquip.type) {
						case itemType.Weapon:
								if (toSlot1) {
										if (equipped [0] != null) {
												items.Add (equipped [0]);
												equipped [0] = null;
												Destroy (weaponSlot_1.transform.GetChild (0).gameObject);
										}
										// удаляем вещь из инвентаря
										items.Remove (_itemToEquip);
										// добавляем ее к одетым вещам
										equipped [0] = _itemToEquip;
										// создаем у игрока эту вещь
										GameObject itemGameObject = (GameObject)Instantiate (_itemToEquip.prefabToEquip, weaponSlot_1.transform.position, weaponSlot_1.transform.rotation);
										// так как игрок одел вещь, то она является его чайлдом
										itemGameObject.transform.parent = weaponSlot_1.transform;
										_itemToEquip = null;
										toSlot1 = false;
								}
								if (toSlot2) {
										Debug.Log (equipped.Length.ToString ());
										if (equipped [1] != null) {
												items.Add (equipped [1]);
												equipped [1] = null;
												Destroy (weaponSlot_2.transform.GetChild (0).gameObject);
										}
										// удаляем вещь из инвентаря
										items.Remove (_itemToEquip);
										// добавляем ее к одетым вещам
										equipped [1] = _itemToEquip;
										// создаем у игрока эту вещь
										GameObject itemGameObject = (GameObject)Instantiate (_itemToEquip.prefabToEquip, weaponSlot_2.transform.position, weaponSlot_2.transform.rotation);
										// так как игрок одел вещь, то она является его чайлдом
										itemGameObject.transform.parent = weaponSlot_2.transform;
										_itemToEquip = null;
										toSlot2 = false;
								}
								break;

						}
				}
		}
	
		// отображение инвентаря
		public void OnGUI ()
		{
				if (showInventory) {
						Screen.showCursor = true;
						Screen.lockCursor = false;
						if (GUI.Button (new Rect (10, 10, 150, 25), "Hide Inventory")) {
								showInventory = !showInventory;
						}
						/*GUILayout.BeginArea(new Rect(Screen.width-400, 10, 190, Screen.height-20), GUI.skin.box);
			{
				_inventoryScroll2 = GUILayout.BeginScrollView(_inventoryScroll2, GUILayout.ExpandHeight(true),GUILayout.ExpandWidth(true));
				 
				for(int i = 0; i<equipped.Length; i++)
				{
					if(equipped[i]!=null)
					{
						GUILayout.BeginVertical(GUI.skin.box);
						GUILayout.Label(equipped[i].itemName); // Название
						GUILayout.BeginHorizontal();
						GUILayout.Label(equipped[i].inventoryTexture); // Иконка
						GUILayout.BeginVertical();
						GUILayout.EndVertical();
						GUILayout.EndHorizontal();
						GUILayout.EndVertical();
					}
				}
			}*/
						GUILayout.BeginArea (new Rect (Screen.width - 200, 10, 190, Screen.height - 20), GUI.skin.box);
						{
								_inventoryScroll = GUILayout.BeginScrollView (_inventoryScroll, GUILayout.ExpandHeight (true), GUILayout.ExpandWidth (true));
				
								// рисуем каждую вещь инвентаря
								foreach (InventoryItem item in items) {
										GUILayout.BeginVertical (GUI.skin.box);
										GUILayout.Label (item.itemName); // Название
										GUILayout.BeginHorizontal ();
										GUILayout.Label (item.inventoryTexture); // Иконка
										GUILayout.BeginVertical ();
										switch(item.type)
										{
										case itemType.Weapon:
												if (GUILayout.Button ("Equip to slot 1")) {  // Кнопка "надеть"
														toSlot1 = true;
														_itemToEquip = item;
												}
												if (GUILayout.Button ("Equip to slot 2")) {  // Кнопка "надеть"
														toSlot2 = true;
														_itemToEquip = item;
												}
						break;
										case itemType.Medkit:
						if (GUILayout.Button ("Use")) 
						{
							this.gameObject.SendMessage("AddHeals",item.Properties[0]);
							items.Remove(item);
						}
						break;
					}
										/* else {
												if (GUILayout.Button ("Equip")) {  // Кнопка "надеть"
														_itemToEquip = item;
												}
										}*/
										if (GUILayout.Button ("Drop")) {  // Кнопка "бросить"
												_itemToDrop = item;
										}
										GUILayout.EndVertical ();
										GUILayout.EndHorizontal ();
										GUILayout.EndVertical ();
								}
				
				
								GUILayout.EndScrollView ();
						}
						GUILayout.EndArea ();
			
				} else if (showInventory == false) {
						Screen.showCursor = false;
						Screen.lockCursor = true;
						if (GUI.Button (new Rect (10, 10, 150, 25), "Show Inventory")) {

								showInventory = !showInventory;
						}
				}
		}
	
	
		// подбор вещи
		public void Equip (object item)
		{
				SceneItem sceneItem = (SceneItem)item;
		
				if (sceneItem != null) {
						// добавляем вещь в инвентарь
						items.Add (sceneItem.prefab);
						// уничтожаем объект сцены
						Destroy (sceneItem.gameObject);
				}
		
		}
	
}
