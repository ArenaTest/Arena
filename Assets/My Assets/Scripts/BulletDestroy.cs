using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	public float LifeTime = 5.0f;
	public float Damage;
	// Update is called once per frame
	void Start () {
		Destroy(gameObject,LifeTime);
	}
	void Update()
	{
		//RaycastHit(
	}
	void OnCollisionEnter(Collision coll)
	{

						if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Damage") { 
								networkView.RPC("applyDamage", coll.gameObject.networkView.owner, coll.gameObject.networkView.viewID, Damage);
								//coll.collider.SendMessageUpwards ("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
								//Network.Destroy(coll.gameObject);
								
						}
						Network.Destroy (this.gameObject);
				
	}
	void SetDamage(float damage)
	{
		Damage = damage;
	}
	[RPC]
	void applyDamage(NetworkViewID id, float damage)
	{
		GameObject[] Players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in Players) {
					if(player.networkView.viewID == id)
					{
						player.SendMessage ("ApplyDamage", damage);
						break;
					}
				}
	}
	/*void DestroyBullet()
	{
		Network.Destroy (this.gameObject);
	}*/
}
