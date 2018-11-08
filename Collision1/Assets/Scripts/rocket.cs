using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

	private Rigidbody2D Body;
	private float Force = 5F;

	// Use this for initialization
	void Start () {
		Body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D( Collision2D io_collider ){
		
		Body.AddForce( Vector2.left, ForceMode2D.Force );
		Debug.Log("colidiu com" +io_collider.gameObject.name);

	}
}
