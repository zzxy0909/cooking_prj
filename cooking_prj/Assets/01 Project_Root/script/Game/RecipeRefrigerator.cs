using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

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

    public void SetAll_ActiveEventType(E_CookingItemType e, bool b_active, bool b_effect = false)
    {
        for (int i = 0; i < m_lstItem.Count; i++)
        {
            if (m_lstItem[i] != null && m_lstItem[i].m_eCookingItemType == e)
            {
                m_lstItem[i].SetActiveEvent(b_active, b_effect);
            }
        }
    }

    public void Show()
    {
        m_ViewRoot.gameObject.SetActive(true);

        for(int i=0; i< m_lstItem.Count; i++)
        {
            if (m_lstItem[i] != null && m_lstItem[i].m_sprObject != null)
            {
                m_lstItem[i].m_sprObject.transform.DORewind();
            }
        }
    }
    
    public void Hide()
    {
        m_ViewRoot.gameObject.SetActive(false);
    }

    public void ShowHelp()
    {
        for (int i = 0; i < m_lstItem.Count; i++)
        {
            if (m_lstItem[i].m_isActiveEvent == true && m_lstItem[i].m_sprObject != null)
            {
                m_lstItem[i].m_sprObject.transform.DORewind();
                m_lstItem[i].m_sprObject.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }
}
