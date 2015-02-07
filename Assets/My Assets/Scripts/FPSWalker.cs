using UnityEngine;

//тот самый аттрибут класса
[RequireComponent(typeof(CharacterController))]
//не забыли переименовать класс и файл и указать наследование
public class FPSWalker : MonoBehaviour {
	//это надо показать в редакторе, обращаем внимание на float 
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float walk_speed = 6.0f;
	public float run_speed = 12.0f;
	public float max_stamina = 100;
	public float damage_high = 5;
	//а это - не надо
	private float damage_time;
	private float _damage_timer = 0;
	private float stamina;
	private bool run;
	private float run_coef;
	private float speed = 6.0f;
	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	private bool useNetwork = false;
	//сюда класть инициализцию
	void Start () {
		if (transform.GetComponent<NetworkView> ())
						useNetwork = true;
				else
						useNetwork = false;
		if (networkView.isMine || !useNetwork) {
						damage_time = damage_high / gravity * Time.deltaTime + 1.0f;
						stamina = max_stamina;
						run = false;
						run_coef = run_speed / walk_speed;
				}
	}
	void Update()
	{
		if (networkView.isMine || !useNetwork) {
						if (Input.GetButtonUp ("Run") || Input.GetAxis ("Vertical") <= 0 || stamina <= 0) {
								run = false;
						} else
		if (Input.GetButtonDown ("Run") && stamina > (max_stamina) * 0.3) {
								run = true;
						}
						if (run) {
								stamina -= Time.deltaTime;
						} else if (stamina < max_stamina) {
								stamina += Time.deltaTime;
						}
				}
		/*if (grounded) {
						if (_damage_timer > 0) {
				;
								_damage_timer -= damage_time;
								if (_damage_timer > 0) {
								gameObject.SendMessageUpwards("ApplyDamage", gravity*_damage_timer, SendMessageOptions.DontRequireReceiver);
								}
								_damage_timer = 0;
						}
				}else {

				}*/
	}
	void FixedUpdate() {
		if (networkView.isMine || !useNetwork) {
						if (grounded) {
								if (run) {
										moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical") * run_coef);
								} else {
										moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
								}
								moveDirection = transform.TransformDirection (moveDirection);
								moveDirection *= speed;
			
								if (Input.GetKey (KeyCode.Space)) {
										moveDirection.y = jumpSpeed;
								}
						} else {
								_damage_timer += Time.deltaTime;
								moveDirection.y -= gravity * Time.deltaTime;
						}
						//не забываем приведение типов
						CharacterController controller = (CharacterController)GetComponent (typeof(CharacterController));
						CollisionFlags flags = controller.Move (moveDirection * Time.deltaTime);
						grounded = (flags & CollisionFlags.CollidedBelow) != 0;
				}
				
	}
	void OnGUI()
	{
		if (networkView.isMine || !useNetwork) {
						GUI.Box (new Rect (0, Screen.height - 30, 100, 30), "Stamina:" + stamina);
				}
	}

	/*void MoveX(float x)
	{
		moveDirection.x = x;
	}
	void MoveY(float y)
	{
		moveDirection.y = y;
	}
	void MoveZ(float z)
	{
		moveDirection.z = z;
	}
	void MoveZero()
	{
			if (moveDirection.x < 0)
				moveDirection.x += Time.deltaTime;
			if (moveDirection.x > 0)	
				moveDirection.x -= Time.deltaTime;
			if (moveDirection.z < 0)
				moveDirection.z += Time.deltaTime;
			if (moveDirection.z > 0)	
				moveDirection.z -= Time.deltaTime;
				
		}*/
}