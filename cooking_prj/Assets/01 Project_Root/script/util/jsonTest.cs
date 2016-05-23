using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class jsonTest : MonoBehaviour {
    public TextAsset m_TextData;

	// Use this for initialization
	void Start () {

        var newList = JsonConvert.DeserializeObject<List<TestData>>(m_TextData.text);

        Debug.Log("~~~~~~~~~~~~ OK :"+ newList.Count +"  0:"+ newList[0].item_name);

        for(int i=0; i< newList.Count; i++)
        {
            Debug.Log("~~~~~~~~~~~~ i:" + i + "  item_name:" + newList[i].item_name + " speed:" + newList[i].speed);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class TestData
{
    public string item_name { get; set; }
    public float speed { get; set; }
    public float up_speed { get; set; }
    public int cost { get; set; }
    public int up_cost { get; set; }
}
