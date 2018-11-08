using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {

	public GameObject MeteorPrefab;
	
	private GameObject Meteor;
	private float Speed = 10F;
	
	void Awake(){
		Meteor = Instantiate(MeteorPrefab, MeteorPrefab.transform.position, MeteorPrefab.transform.rotation);
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
			Meteor.transform.Translate( Vector2.right * Time.deltaTime * Speed );
		}
		if ( Input.GetKey( KeyCode.LeftArrow ) )
		{
			Meteor.transform.Translate( Vector2.left * Time.deltaTime * Speed );
		}
		if ( Input.GetKey( KeyCode.UpArrow ) )
		{
			Meteor.transform.Translate( Vector2.up * Time.deltaTime * Speed );
		}
		if ( Input.GetKey( KeyCode.DownArrow ) )
		{
			Meteor.transform.Translate( Vector2.down * Time.deltaTime * Speed );
		}
		// -----------------------
	}

}