using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gui_Refrigerator : GuiBase
{
    public List<Transform> m_lstItem;
     
    public override void SetInspactor_InitTransList()
    {
    }
    
	public override void _OnEnable()
	{		

	}
    
    public Transform GetItem(int ix)
    {
        return m_lstItem[ix];
    }
}
