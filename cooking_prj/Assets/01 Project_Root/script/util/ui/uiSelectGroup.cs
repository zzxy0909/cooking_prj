using UnityEngine;
using System.Collections;

public class uiSelectGroup : MonoBehaviour {
    public uiSelectButton[] m_ArrSelectButton;
    public int m_CurrentIx;
    public System.Action m_OnChangeEvent;

    public void ChangeButton(int ix)
    {
        for (int i = 0; i < m_ArrSelectButton.Length; i++)
        {
            if (i == ix)
            {
                m_ArrSelectButton[ix].SetActiveSprite(true);
            }
            else
            {
                m_ArrSelectButton[i].SetActiveSprite(false);
            }
        }

        m_CurrentIx = ix;

        if(m_OnChangeEvent != null)
        {
            m_OnChangeEvent();
        }
    }
}
