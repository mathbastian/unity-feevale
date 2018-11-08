using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex2Controller : MonoBehaviour {

	public GameObject RocketPrefab;

	private GameObject Rocket;
	private float Speed = 20F;

	void Awake(){
		Rocket = Instantiate( RocketPrefab, 
							  RocketPrefab.transform.position, 
							  RocketPrefab.transform.rotation );

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		control();
	}

	private void control(){
		// Movement:
		if ( Input.GetKey( KeyCode.RightArrow ) )
		{
			Rocket.GetComponent<Rigidbody2D>().AddForce( Vector2.right * Speed, ForceMode2D.Impulse );
		}
		if ( Input.GetKey( KeyCode.LeftArrow ) )
		{
			Rocket.GetComponent<Rigidbody2D>().AddForce( Vector2.left * Time.deltaTime * Speed, ForceMode2D.Force );
		}
		// -----------------------
	}

}