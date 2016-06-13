using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class RecipeWorktops : MonoBehaviour {
    public Transform m_ViewRoot;
    public GameObject m_prefabSprCooking;

    public List<CookingItem> m_lstItem; // 현재 설정된 요리장비(도마, 접시, 불판, 오븐 등) 아이템

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Transform GetItem(int ix)
    {
        return m_lstItem[ix].transform;
    }

    public CookingItem GetItem_ChoppingBoard1()
    {
        for(int i=0; i<m_lstItem.Count; i++)
        {
            if(m_lstItem[i].m_eCookingItemType == E_CookingItemType.ChoppingBoard1)
            {
                return m_lstItem[i];
            }
        }
        return null;
    }
    public CookingItem GetItem(E_CookingItemType e )
    {
        for (int i = 0; i < m_lstItem.Count; i++)
        {
            if (m_lstItem[i] != null && m_lstItem[i].m_eCookingItemType == e)
            {
                return m_lstItem[i];
            }
        }
        return null;
    }

    public CookingItem SpawnItemOnItemType(GameObject prefabSprCooking, E_CookingItemType e_type, CookingItem item_data = null)
    {
        CookingItem target_item = GetItem(e_type);
        if (target_item.m_CookSlot != null)
        {
            GuiSpawnerPool.Destroy(target_item.m_CookSlot);
        }
        target_item.m_CookSlot = GuiSpawnerPool.Spawn(prefabSprCooking, target_item.m_CookSlotPos.position, target_item.m_CookSlotPos.rotation);
        target_item.m_CookSlot.transform.SetParent(target_item.transform);

        // target_item.m_CookSlot.SetActive(true); // SetParent 로 해당 판넬로 이동 하여 다시 액티브 시킴.
        StartCoroutine(_ReActiveGameObject(target_item.m_CookSlot));

        return target_item;
    }

    // 해당 아이템 위에 올린다.
    public bool CopyItemOnItemType(UISprite spr, E_CookingItemType e_type, CookingItem item_data = null)
    {
        CookingItem target_item = GetItem(e_type);
        if (target_item.m_CookSlot != null)
        {
            return false;
            // GuiSpawnerPool.Destroy(target_item.m_CookSlot);
        }
        target_item.m_CookSlot = GuiSpawnerPool.Spawn(m_prefabSprCooking, target_item.m_CookSlotPos.position, target_item.m_CookSlotPos.rotation);

        target_item.m_CookSlot.transform.SetParent(target_item.transform);
        UISprite sprTarget = target_item.m_CookSlot.GetComponent<UISprite>();
        sprTarget.spriteName = spr.spriteName;
        sprTarget.SetDimensions(spr.width, spr.height);
        sprTarget.depth = spr.depth;

        if(item_data != null)
        {
            // 무엇이 올려졌는지 확인 위해 data 유지 한다.
            CookingItem tmp_sor = target_item.m_CookSlot.GetComponent<CookingItem>();
            tmp_sor.m_eCookingItemGroupType = item_data.m_eCookingItemGroupType;
            tmp_sor.m_eCookingItemType = item_data.m_eCookingItemType;

        }

        // target_item.m_CookSlot.SetActive(true); // NGUI 판넬 오더 관련 하여 처리- SetParent 로 해당 판넬로 이동 하여 다시 액티브 시킴.
        StartCoroutine(_ReActiveGameObject(target_item.m_CookSlot));

        return true;
    }

    //public CookingItem CopyItemOnChoppingBoard(UISprite spr)
    //{
    //    CookingItem target_item = GetItem(E_CookingItemType.ChoppingBoard1);
    //    if (target_item.m_CookSlot != null)
    //    {
    //        GuiSpawnerPool.Destroy(target_item.m_CookSlot);
    //    }
    //    target_item.m_CookSlot = GuiSpawnerPool.Spawn(m_prefabSprCooking, spr.transform.position, spr.transform.rotation);

    //    target_item.m_CookSlot.transform.SetParent(target_item.transform);
    //    UISprite sprTarget = target_item.m_CookSlot.GetComponent<UISprite>();
    //    sprTarget.spriteName = spr.spriteName;
    //    sprTarget.SetDimensions(spr.width, spr.height);
    //    sprTarget.depth = spr.depth;

    //    // target_item.m_CookSlot.SetActive(true); // SetParent 로 해당 판넬로 이동 하여 다시 액티브 시킴.
    //    StartCoroutine(_ReActiveGameObject(target_item.m_CookSlot));

    //    return target_item;
    //}
    //public CookingItem CopyItemOnPan1(UISprite spr)
    //{
    //    CookingItem target_item = GetItem(E_CookingItemType.Pan1);
    //    if (target_item.m_CookSlot != null)
    //    {
    //        // 이미 올라가 있는 것이 있다면, 올리지 않는다.
    //        return target_item;

    //        // GuiSpawnerPool.Destroy(target_item.m_CookSlot);
    //    }
    //    target_item.m_CookSlot = GuiSpawnerPool.Spawn(m_prefabSprCooking, spr.transform.position, spr.transform.rotation);

    //    target_item.m_CookSlot.transform.SetParent(target_item.transform );
    //    UISprite sprTarget = target_item.m_CookSlot.GetComponent<UISprite>();
    //    sprTarget.spriteName = spr.spriteName;
    //    sprTarget.SetDimensions(spr.width, spr.height);
    //    sprTarget.depth = spr.depth;

    //    // target_item.m_CookSlot.SetActive(true); // SetParent 로 해당 판넬로 이동 하여 다시 액티브 시킴.
    //    StartCoroutine(_ReActiveGameObject(target_item.m_CookSlot));
    //    return target_item;
    //}
    //// Oven
    //public CookingItem CopyItemOnOven1(UISprite spr)
    //{
    //    CookingItem target_item = GetItem(E_CookingItemType.Oven1);

    //    if (target_item.m_CookSlot != null)
    //    {
    //        GuiSpawnerPool.Destroy(target_item.m_CookSlot);
    //    }
    //    target_item.m_CookSlot = GuiSpawnerPool.Spawn(m_prefabSprCooking, spr.transform.position, spr.transform.rotation);

    //    target_item.m_CookSlot.transform.SetParent(target_item.transform);
    //    UISprite sprTarget = target_item.m_CookSlot.GetComponent<UISprite>();
    //    sprTarget.spriteName = spr.spriteName;
    //    sprTarget.SetDimensions(spr.width, spr.height);
    //    sprTarget.depth = spr.depth;

    //    // _sprOnOven1.SetActive(true); // SetParent 로 해당 판넬로 이동 하여 다시 액티브 시킴.
    //    StartCoroutine(_ReActiveGameObject(target_item.m_CookSlot));

    //    return target_item;
    //}


    IEnumerator _ReActiveGameObject(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForEndOfFrame();
        obj.SetActive(true);

    }

    public void Show()
    {
        m_ViewRoot.gameObject.SetActive(true);

        for (int i = 0; i < m_lstItem.Count; i++)
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
            if (m_lstItem[i] != null && m_lstItem[i].m_isActiveEvent == true && m_lstItem[i].m_sprObject != null)
            {
                m_lstItem[i].m_sprObject.transform.DORewind();
                m_lstItem[i].m_sprObject.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }
}
