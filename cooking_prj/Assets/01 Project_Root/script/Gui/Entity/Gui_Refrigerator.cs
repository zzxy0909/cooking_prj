using UnityEngine;
using System.Collections;

public class Gui_Refrigerator : GuiBase
{
    public RecipeRefrigerator[] m_arrRecipeRefrigerator;
    public E_RecipeEnum m_CurrentRecipe;  // 냉장고에서는 선택된 레시피를 가져 가야 한다.

     
    public override void SetInspactor_InitTransList()
    {
    }
    
	public override void _OnEnable()
	{		

	}
    
    public void Start()
    {
        ShowRecipe(m_CurrentRecipe);
    }

    public CookingItem GetItem(int ix)
    {
        return m_arrRecipeRefrigerator[(int)m_CurrentRecipe].m_lstItem[ix];
    }

    public void HideAll()
    {
        for(int i=0; i< m_arrRecipeRefrigerator.Length; i++)
        {
            m_arrRecipeRefrigerator[i].HideMaterials();
        }

    }
    public void ShowRecipe(E_RecipeEnum e)
    {
        SetCurrentRecipe(e);
        HideAll();
        m_arrRecipeRefrigerator[(int)m_CurrentRecipe].ShowMaterials();
    }
    public void SetCurrentRecipe(E_RecipeEnum e)
    {
        m_CurrentRecipe = e;
    }
}
