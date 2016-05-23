using UnityEngine;
using System.Collections;

public class uiSelectButton : MonoBehaviour {
    public uiSelectGroup m_OwnerGroup;
    public int m_index;
    public GameObject m_ActiveRoot;
    public GameObject m_DeactiveRoot;

    public void SetActiveSprite(bool b)
    {
        if(b)
        {
            m_ActiveRoot.SetActive(true);
            m_DeactiveRoot.SetActive(false);
        }
        else
        {
            m_ActiveRoot.SetActive(false);
            m_DeactiveRoot.SetActive(true);
        }
    }
    public void OnClickSelect()
    {
        m_OwnerGroup.ChangeButton(m_index);
    }
}
