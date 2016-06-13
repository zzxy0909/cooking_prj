using UnityEngine;
using System.Collections;


public class Gui_Worktops : GuiBase
{
    public RecipeWorktops[] m_arrRecipeWorktops;
    public E_RecipeEnum m_CurrentRecipe;  // CookManager.Instance.m_CurrentRecipe

    public override void SetInspactor_InitTransList()
    {
    }
    
	public override void _OnEnable()
	{		

	}

    public void HideAll()
    {
        for (int i = 0; i < m_arrRecipeWorktops.Length; i++)
        {
            m_arrRecipeWorktops[i].Hide();
        }

    }
    public void ShowRecipe(E_RecipeEnum e)
    {
        SetCurrentRecipe(e);
        HideAll();
        m_arrRecipeWorktops[(int)m_CurrentRecipe].Show();
    }
    public void SetCurrentRecipe(E_RecipeEnum e)
    {
        m_CurrentRecipe = e;
    }
    public void ShowHelp()
    {
        m_arrRecipeWorktops[(int)m_CurrentRecipe].ShowHelp();
    }
    public CookingItem GetItem(E_CookingItemType e)
    {
        return m_arrRecipeWorktops[(int)m_CurrentRecipe].GetItem(e);
    }
}
