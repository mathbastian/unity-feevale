using System;
using UnityEngine;
using System.Collections;
using System.IO;
//using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {

    private string innerText = "";
    string strFileXML = "RankingPlayers";
    
    public Text pontosListText;
    public Text pontosSave;
    public Text nomeSave;

	// Use this for initialization
	void Start () {
        View();
        }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void View()
    {
        innerText = "";
        pontosListText.text = "";

        string m_XmlTextAssetPath = Application.dataPath.ToString() + @"/Resources/" + strFileXML.Trim() + ".xml";
        Ranking r = new Ranking();
        if (File.Exists(m_XmlTextAssetPath))
        {
            r = XmlSupport.Deserialize<Ranking>(strFileXML);
        }
        if (!r.Equals(null))
        {
            foreach (var item in r.players)
            {
                innerText += item.nome + " - " + item.ponto.ToString() + "\n";
            }
            pontosListText.text = innerText;
        }
    }

    public void AdicionaPontos()
    {
        PlayerRanking a = new PlayerRanking();
        Ranking r = new Ranking();
        string m_XmlTextAssetPath = Application.dataPath.ToString() + @"/Resources/" + strFileXML.Trim() + ".xml";
        if (File.Exists(m_XmlTextAssetPath))
        {
            r = XmlSupport.Deserialize<Ranking>(strFileXML);
        }   
        a.nome = nomeSave.text;
        a.ponto = Convert.ToInt32(pontosSave.text);
        r.players.Add(a);
        XmlSupport.Serialize<Ranking>(strFileXML, r);
        View();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }


}
