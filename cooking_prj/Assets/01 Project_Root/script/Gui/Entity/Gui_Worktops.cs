using UnityEngine;
using System.Collections;


public class Gui_Worktops : GuiBase
{
    public CookingEventRecipeGroup[] m_arrEventRecipeGroup;

    public override void SetInspactor_InitTransList()
    {
    }
    
	public override void _OnEnable()
	{		

	}
	
    public void SpawnChoppingBoard(int recipeIx, UISprite sor )
    {
        m_arrEventRecipeGroup[recipeIx].SpawnChoppingBoard(sor);
    }
}
