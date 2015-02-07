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
	[RPC]
	void OnCollisionEnter(Collision coll)
	{
		if (networkView.isMine) {
						if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Damage") { 
								coll.collider.SendMessageUpwards ("ApplyDamage", Damage/*, SendMessageOptions.DontRequireReceiver*/);
								//Network.Destroy(coll.gameObject);
								
						}
						Network.Destroy (this.gameObject);
				}
	}
	void SetDamage(float damage)
	{
		Damage = damage;
	}

	/*void DestroyBullet()
	{
		Network.Destroy (this.gameObject);
	}*/
}
