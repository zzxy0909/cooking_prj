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
    public void AddCheckIx(int ix)
    {
        int recipeIx = (int)CookManager.Instance.m_CurrentRecipe;
        m_RecipeItemOnEffect[recipeIx].AddCheckIx(ix);
    }
    public void PlayOnRecipe(RecipeItemOnEffect.E_EffectType etype, Transform effectPos = null)
    {
        int recipeIx = (int)CookManager.Instance.m_CurrentRecipe;
        m_RecipeItemOnEffect[recipeIx].PlayOnRecipe(etype, effectPos);
    }
}
