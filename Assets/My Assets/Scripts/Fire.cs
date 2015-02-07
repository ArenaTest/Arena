using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
		
		public Rigidbody Body;
		public Texture2D AimTexture;
		public Transform Flash;
		public Light Flashlight;
		public AudioClip ShootSound;
		public AudioClip ReloadSound;
		public gunMode _gunMode;
		public float speed = 10;
		public int AmmoCount = 0;
		public int InventoryAmmo = 0;
		public float ReloadTime = 1.0f;
		public int AimWightOffset;
		public int AimHeigtOffset;
		public float FireSpeed = 0.5f;
		public bool CanChangeGunMode = true;
		public float MaxDispersion = 10.0f;
		public float MinDispersion = 0.5f;		
		public float MinDamage = 15; 
		public float MaxDamage = 35;
		public AnimationClip reload;

		private int count;
		private float _fireSpeedTimer;
		//private float _reloadTimer = 0.0f;
		private bool _reloadFlag = false;
		private float dispersion;
		private float _flashTimer = 0.0f;
		public GameObject Gun;	 
	public enum gunMode
	{
		semi,
		auto
	}


		void Start ()
		{
				Gun = gameObject.transform.parent.gameObject;
				Gun.animation.AddClip (reload, "Reload");
				//Gun.animation.
				Flash.active = false;
				Flashlight.active = false;
				count = AmmoCount;
				dispersion = MinDispersion;
				Screen.lockCursor = true;
				Screen.showCursor = false;

		//Gun.animation.Play("Equip_AK-47");
				
		}
		// Update is called once per frame
		void Update ()
		{
		if (networkView.isMine) {
						if (dispersion > MinDispersion) {
								dispersion -= Time.deltaTime * 5;
						}
						if (dispersion < MinDispersion) {
								dispersion = MinDispersion;
						}

						if (Input.GetButtonDown ("Shot type") && CanChangeGunMode) {
								switch (_gunMode) {
								case gunMode.auto:
										_gunMode = gunMode.semi;
										break;
								case gunMode.semi:
										_gunMode = gunMode.auto;
										break;
								}
						}
						if (_fireSpeedTimer > 0) {
								_fireSpeedTimer -= Time.deltaTime;
						} else {
								if (_gunMode == gunMode.auto) {
										if (Input.GetButton ("Fire1") && count != 0 && _reloadFlag == false /*&& !Screen.showCursor*/) {
												Shoot ();
										}
								} else if (_gunMode == gunMode.semi) {
										if (Input.GetButtonDown ("Fire1") && count != 0 && _reloadFlag == false /*&& !Screen.showCursor*/) {
												Shoot ();
										}
								}
						}
						if (_flashTimer > 0) {
								_flashTimer -= Time.deltaTime;
						} else if (_flashTimer < 0) {
								Flash.active = false;
								Flashlight.active = false;
						}
						if (Input.GetButtonDown ("Reload") && count < AmmoCount && InventoryAmmo != 0 && _reloadFlag == false) {
								//_reloadTimer = ReloadTime;
								_reloadFlag = true;
								Gun.animation.Play ("Reload");
						}
						if (Gun.animation.IsPlaying ("Reload")) {//_reloadTimer > 0)
								//_reloadTimer -= Time.deltaTime;
						} else if (_reloadFlag) {
								Reload ();
						}
				}
		}

		void OnGUI ()
		{
			if (networkView.isMine) {
						GUI.DrawTexture (new Rect (Screen.width / 2 - AimTexture.width / 2 + AimWightOffset, Screen.height / 2 - AimTexture.height / 2 + AimHeigtOffset, AimTexture.width, AimTexture.height), AimTexture);
						GUI.Box (new Rect (Screen.width - 100, Screen.height - 50, 100, 50), "Ammo:" + count + "/" + AmmoCount + "\n" + InventoryAmmo);
				}
		}

		void Reload ()
		{
					audio.PlayOneShot(ReloadSound);
						if (InventoryAmmo + count > AmmoCount) {
								InventoryAmmo = InventoryAmmo - AmmoCount + count;
								count = AmmoCount;
						} else {
								count += InventoryAmmo;
								InventoryAmmo = 0;
						}
			_reloadFlag = false;
				
		}

	void Shoot()
	{
		if (networkView.isMine) {
						Rigidbody newBody;
						_fireSpeedTimer = FireSpeed;
						audio.PlayOneShot (ShootSound);
						//Vector3 vect = transform.rotation;
						newBody = (Rigidbody)Network.Instantiate (Body, transform.position, transform.rotation, 1);
						newBody.gameObject.SendMessage ("SetDamage", Random.Range (MinDamage, MaxDamage));
						newBody.velocity = transform.TransformDirection (new Vector3 (speed, Random.Range (-dispersion, dispersion), Random.Range (-dispersion, dispersion)));
						//newBody.gameObject.AddComponent<NetworkView>();
						count -= 1;
						if (dispersion < MaxDispersion) {
								dispersion++;
						}
						Flash.active = true;
						Flashlight.active = true;
						_flashTimer = 0.1f;
				}
	}
	void AddBullets(int size)
	{
		InventoryAmmo += size;
	}
}

