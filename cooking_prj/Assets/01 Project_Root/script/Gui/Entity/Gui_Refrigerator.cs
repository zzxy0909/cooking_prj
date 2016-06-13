using UnityEngine;
using System.Collections;

public class Gui_Refrigerator : GuiBase
{
    public RecipeRefrigerator[] m_arrRecipeRefrigerator;
    public E_RecipeEnum m_CurrentRecipe;  // CookManager.Instance.m_CurrentRecipe


    public override void SetInspactor_InitTransList()
    {
    }
    
	public override void _OnEnable()
	{		

	}
    
    public void Start()
    {
//         ShowRecipe(m_CurrentRecipe);
    }

    public CookingItem GetItem(int ix)
    {
        return m_arrRecipeRefrigerator[(int)m_CurrentRecipe].m_lstItem[ix];
    }

    public void HideAll()
    {
        for(int i=0; i< m_arrRecipeRefrigerator.Length; i++)
        {
            m_arrRecipeRefrigerator[i].Hide();
        }

    }
    public void ShowRecipe(E_RecipeEnum e)
    {
        SetCurrentRecipe(e);
        HideAll();
        m_arrRecipeRefrigerator[(int)m_CurrentRecipe].Show();
    }
    public void SetCurrentRecipe(E_RecipeEnum e)
    {
        m_CurrentRecipe = e;
    }

    public void ShowHelp()
    {
        m_arrRecipeRefrigerator[(int)m_CurrentRecipe].ShowHelp();
    }

    public void SetAll_ActiveEventType(E_CookingItemType e, bool b_active, bool b_effect = false)
    {
        m_arrRecipeRefrigerator[(int)m_CurrentRecipe].SetAll_ActiveEventType(e, b_active, b_effect);
    }


}
