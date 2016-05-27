using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AppGameString : MonoBehaviour {

    #region Singleton
    private static GuiManager _instance = null;
    public static GuiManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion Singleton

    static  IDictionary <string, string> _content = new Dictionary<string, string>();
    public static string app_name { get { return _content["app_name"]; } }
    public static string sample1 { get { return _content["sample1"]; } }


    public TextAsset xmlFile; //Attach XML File here, or load it by Resources.Load  안드로이드 인 경우 res/values/string.xml 로드.
    XmlDocument doc;

    string _tmpKey;
    string _tmpValue;
    void Awake()
    {
        doc = new XmlDocument();
        doc.LoadXml(xmlFile.text);

        XmlNodeList res = doc.GetElementsByTagName("resources");

        foreach (XmlNode n in res)
        {
            // Debug.Log(n.Attributes["caption"].Value);
            // Debug.Log("~~~~~~~~ count " + n.ChildNodes.Count);
            for (int i = 0; i < n.ChildNodes.Count; i++)
            {
//                Debug.Log("~~~~~~~ name:" + n.ChildNodes[i].Attributes["name"].Value + " value:" + n.ChildNodes[i].InnerText);
                _tmpKey = n.ChildNodes[i].Attributes["name"].Value;
                _tmpValue = n.ChildNodes[i].InnerText;
                if(_content.ContainsKey(_tmpKey) == false)
                {
                    _content.Add(_tmpKey, _tmpValue);
                }
                else
                {
                    Debug.LogError("~~~~~~~ AppGameString has been found multiple times in the XML allowed only once!");
                }
            }
        }

        string str = string.Format("~~~~~~~~~~~~~~ AppGameString Load ok: {0}", AppGameString.app_name);
        Debug.Log(str);
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update () {
	
	}
}
