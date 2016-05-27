using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeRefrigerator : MonoBehaviour {
    public Transform m_ViewRoot;

    public List<CookingItem> m_lstItem; // 현재 설정된 제료 아이템

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public CookingItem GetItem(int ix)
    {
        return m_lstItem[ix];
    }

    public void ShowMaterials()
    {
        m_ViewRoot.gameObject.SetActive(true);
    }
    public void HideMaterials()
    {
        m_ViewRoot.gameObject.SetActive(false);
    }
}
