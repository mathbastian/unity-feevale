using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {

	public GameObject mo_prefab;

	// Use this for initialization
	void Start () {

		Instanciador lo_instantiator = gameObject.AddComponent<Instanciador>();
		lo_instantiator.InstanciarObjeto( mo_prefab );
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}