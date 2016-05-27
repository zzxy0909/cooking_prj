using UnityEngine;
using System.Collections;


public class Gui_RecipeManager : GuiBase
{
    public RecipeItemOnEffect[] m_RecipeItemOnEffect;

    public override void SetInspactor_InitTransList()
    {
    }
    
	public override void _OnEnable()
	{		

	}

    public void HideRecipeAll()
    {
        for(int i=0; i< m_RecipeItemOnEffect.Length; i++)
        {
            m_RecipeItemOnEffect[i].HideRecipe();
        }
    }
}
