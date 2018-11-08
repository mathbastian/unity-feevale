using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public float smooth = 0.5F;

	private Vector2 speed;

	// Use this for initialization
	void Start () {
		speed = new Vector2( 0.5F, 0.5F );
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 lo_position2D = Vector2.zero;

		lo_position2D.x = Mathf.SmoothDamp( transform.position.x, player.position.x, ref speed.x, smooth );
		lo_position2D.y = Mathf.SmoothDamp( transform.position.y, player.position.y+1.5F, ref speed.y, smooth );

		Vector3 lo_position3D = new Vector3( lo_position2D.x, lo_position2D.y, transform.position.z );

		transform.position = Vector3.Slerp( transform.position, lo_position3D, Time.time );

	}

}