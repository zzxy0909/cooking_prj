using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeWorktops : MonoBehaviour {
    public Transform m_ViewRoot;
    public GameObject m_prefabSprCooking;

    public List<Transform> m_lstItem; // 현재 설정된 요리장비(도마, 접시, 불판, 오븐 등) 아이템

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Transform GetItem(int ix)
    {
        return m_lstItem[ix];
    }

    GameObject _sprOnChoppingBoard = null;
    public void CopyItemOnChoppingBoard(UISprite spr)
    {
        if(_sprOnChoppingBoard != null)
        {
            GuiSpawnerPool.Destroy(_sprOnChoppingBoard);
        }
        _sprOnChoppingBoard = GuiSpawnerPool.Spawn(m_prefabSprCooking, spr.transform.position, spr.transform.rotation);

        _sprOnChoppingBoard.transform.SetParent(m_lstItem[(int)E_Worktops_HotDog.ChoppingBoard]);
        UISprite sprTarget = _sprOnChoppingBoard.GetComponent<UISprite>();
        sprTarget.spriteName = spr.spriteName;
        sprTarget.SetDimensions(spr.width, spr.height);
        sprTarget.depth = spr.depth;

        // _sprOnChoppingBoard.SetActive(true); // SetParent 로 해당 판넬로 이동 하여 다시 액티브 시킴.
        StartCoroutine(_ReActiveGameObject(_sprOnChoppingBoard));

    }
    IEnumerator _ReActiveGameObject(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForEndOfFrame();
        obj.SetActive(true);

    }

    public void ShowView()
    {
        m_ViewRoot.gameObject.SetActive(true);
    }
    public void HideView()
    {
        m_ViewRoot.gameObject.SetActive(false);
    }
}
