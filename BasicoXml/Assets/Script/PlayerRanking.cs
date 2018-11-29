using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;


public class PlayerRanking{

    [XmlElement("nome")]
    public string nome;
    [XmlElement("ponto")]
    public int ponto;
    
    
}

public class Ranking
{
    [XmlElement("players")]
 
    public List<PlayerRanking> players = new List<PlayerRanking>();
}
