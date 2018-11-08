using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerEnd : MonoBehaviour {

	private Button button;
	private List<Controller> players;

	// Use this for initialization
	void Start () {
		button = GameObject.FindObjectOfType<Button>();
		button.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick(){
		SceneManager.LoadScene(0);
	}

	public void append_winner( Controller io_player ){
		players.Add(io_player);
	}

	public void display_results(){
		foreach (var player in players)
		{
			GameObject.FindGameObjectWithTag("scoreboard").GetComponent<Text>().text += "\n "+
				player.get_name()+": "+
				player.get_result();
		}
	}

}