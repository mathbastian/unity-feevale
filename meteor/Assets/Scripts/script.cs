using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {

	public GameObject mo_meteor_prefab;

	private Ray mo_ray;
	private List<GameObject> mt_meteors = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( Input.GetMouseButtonDown(0) ){
			mo_ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			mt_meteors.Add( Instantiate(mo_meteor_prefab, mo_ray.origin, mo_meteor_prefab.transform.rotation ) );
		}

		foreach (var item in mt_meteors){
			item.transform.Translate( Vector3.down * Time.deltaTime );
		}

	}

}