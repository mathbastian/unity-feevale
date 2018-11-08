using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public GameObject Inicio;
	public GameObject Fim;

	private static float Speed 	   = 6;
	private static float JumpForce = 4;

	private bool		 double_jump_bonus = false;
	private bool		 is_colliding = false;
	private bool		 is_alvo;

	private Animator 	 animator;
	private Rigidbody2D  rigidbody;

	// Use this for initialization
	void Start () {
		animator  = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		control();
	}

	void RayCasting(){
		Debug.DrawLine( Inicio.transform.position, Fim.transform.position, Color.red );
		is_alvo = Physics2D.Linecast( Inicio.transform.position, Fim.transform.position, 1 << LayerMask.NameToLayer("Plataforma"));
		if (is_alvo)
		{
			animator.SetBool("Jump", false);
		}
		else{
			animator.SetBool("Jump", true);
		}
	}

	void control() {
		// Verifica se há colisão
		RayCasting();

		// Normal movement
		if ( Input.GetAxisRaw("Horizontal") > 0 ) {
			run();
			rotate_to_right( ref rigidbody );
			move_to_direction( Vector2.right );
		}
		else if ( Input.GetAxisRaw("Horizontal") < 0 ) {
			run();
			rotate_to_left();
			move_to_direction( Vector2.right );
		}
		else{
			idle();
		}
		
		// Only jump
		if ( Input.GetKeyDown( KeyCode.UpArrow ) && is_colliding ) {
			jump();
			double_jump_bonus = true;
		} // Double jump conditioning
		else if ( Input.GetKeyDown( KeyCode.UpArrow ) && is_colliding == false && double_jump_bonus == true ) {
			jump();
			double_jump_bonus = false;
		}

	}

	void rotate_to_right( ref Rigidbody2D io_rb ){
		io_rb.transform.eulerAngles = new Vector2(0,0);
	}

	void rotate_to_left(){
		rigidbody.transform.eulerAngles = new Vector2(0,180);
	}

	void move_to_direction( Vector2 Direction ){
		transform.Translate( Direction * Time.deltaTime * Speed );
		//rb.AddForce( transform.right * Speed );
	}

	void jump(){
		rigidbody.AddForce( transform.up * JumpForce, ForceMode2D.Impulse );
		//animator.SetTrigger("Jump");
	}

	void run(){
		animator.SetFloat("Value", 1);
		//animator.ResetTrigger("Jump");
	}

	void idle(){
		animator.SetFloat("Value", 0);
		//animator.ResetTrigger("Jump");
	}

	void OnCollisionEnter2D( Collision2D io_collider ){
		is_colliding = true;
	}

	void OnCollisionExit2D( Collision2D io_collider ){
		is_colliding = false;
	}

}