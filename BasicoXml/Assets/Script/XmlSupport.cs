using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class XmlSupport : MonoBehaviour {

    //public static void Serialize<T>(string fileName, T obj)
    //{
    //    string m_XmlTextAssetPath = Application.dataPath.ToString() + @"/Resources/" + fileName.Trim()+".xml";

    //    if (File.Exists(m_XmlTextAssetPath))
    //    {
    //        File.Delete(m_XmlTextAssetPath);
    //    }
    //    XmlSerializer xs = new XmlSerializer(typeof(T));
    //    using (FileStream fs = new FileStream(m_XmlTextAssetPath, FileMode.CreateNew))
    //    {
    //        using (StreamWriter wr = new StreamWriter(fs, Encoding.UTF8))
    //        {
    //            xs.Serialize(wr, obj);
    //        }
    //    }

    //}



    //public static T Deserialize<T>(string fileName)
    //{
        
        
    //    TextAsset textXML = (TextAsset)Resources.Load(fileName, typeof(TextAsset));

    //    XmlSerializer xs = new XmlSerializer(typeof(T));
    //    using (StringReader rd = new StringReader(textXML.text.ToString()))
    //    {
    //        return (T)xs.Deserialize(rd);
    //    }
        
    //    Resources.UnloadAsset (textXML);
    //}

    public static void Serialize<T>(string fileName, T obj)
    {
        string m_XmlTextAssetPath = Application.dataPath.ToString() + @"/Resources/" + fileName.Trim() + ".xml";

        if (File.Exists(m_XmlTextAssetPath))
        {
            File.Delete(m_XmlTextAssetPath);
        }
        XmlSerializer xs = new XmlSerializer(typeof(T));
        using (FileStream fs = new FileStream(m_XmlTextAssetPath, FileMode.CreateNew))
        {
            using (StreamWriter wr = new StreamWriter(fs, Encoding.UTF8))
            {
                xs.Serialize(wr, obj);
            }
        }
    }
    public static T Deserialize<T>(string fileName)
    {
        string m_XmlTextAssetPath = Application.dataPath.ToString() + @"/Resources/" + fileName.Trim() + ".xml";

        XmlSerializer xs = new XmlSerializer(typeof(T));
        using (StreamReader rd = new StreamReader(m_XmlTextAssetPath, System.Text.Encoding.UTF8, true))
        {
            return (T)xs.Deserialize(rd);
        }

    }
}
