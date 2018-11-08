using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerStart : MonoBehaviour {

	private Button button;
	private InputField text;

	// Use this for initialization
	void Start () {
		button = GameObject.FindObjectOfType<Button>();
		button.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick(){
		text = GameObject.FindObjectOfType<InputField>();
		if ( text.text != null || text.text != "" ){
			PlayerPrefs.SetString("name", text.text);
			SceneManager.LoadScene(1);
		}
	}

}