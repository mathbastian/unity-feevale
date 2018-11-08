using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public GameObject Inicio;
	public GameObject Fim;

	private string name;

	private static float Speed 	   = 6F;
	private static float JumpForce = 5F;

	private float time = 0F;
	private float result;

	private bool		 double_jump_bonus = false;
	private bool		 is_colliding = false;
	private bool		 is_alvo;

	private Animator 	 animator;
	private Rigidbody2D  rigidBody;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		name = PlayerPrefs.GetString("name");
		animator  = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		control();
		maintain_score();
	}

	void maintain_score(){
		if ( SceneManager.GetActiveScene().buildIndex == 1 )
		{
			time += Time.deltaTime;
		}
		else if ( SceneManager.GetActiveScene().buildIndex == 2 )
		{
			stop_score();
			display_results();
			clear();
			Destroy(gameObject);
		}
	}

	void clear(){
		PlayerPrefs.DeleteKey("name");
	}

	void stop_score(){
		result = time;
	}

	void display_results(){
		GameObject.FindGameObjectWithTag("scoreboard").GetComponent<Text>().text += "\n "+name+": "+result;
		//GetComponent<ControllerEnd>().append_winner(this);
		//GetComponent<ControllerEnd>().display_results();
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
			rotate_to_right( ref rigidBody );
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
		rigidBody.transform.eulerAngles = new Vector2(0,180);
	}

	void move_to_direction( Vector2 Direction ){
		transform.Translate( Direction * Time.deltaTime * Speed );
		//rb.AddForce( transform.right * Speed );
	}

	void jump(){
		rigidBody.AddForce( transform.up * JumpForce, ForceMode2D.Impulse );
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
		
		// Checking if it is a gem...
		if ( io_collider.gameObject.tag == "gem" ){
			is_colliding = false;
			io_collider.gameObject.GetComponent<Gem>().Catch();
			return;
		}
		
		is_colliding = true;
	}

	void OnCollisionExit2D( Collision2D io_collider ){
		is_colliding = false;
	}

	public string get_name(){
		return name;
	}

	public float get_result(){
		return result;
	}

}