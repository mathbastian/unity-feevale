using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour {

	private string mv_block_number = "0";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void OnCollisionEnter2D( Collision2D io_collider ){
		if ( io_collider.gameObject.name != mv_block_number )
		{
			Debug.Log( "saiu do bloco " + mv_block_number );
			mv_block_number = io_collider.gameObject.name;
			Debug.Log( "entrou no bloco " +mv_block_number );
		}
		
	}
}
