using UnityEngine;
using System.Collections;

public class OrderItem : MonoBehaviour {
    public E_RecipeEnum m_eRecipe;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OrderItemClick()
    {
        Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
        recipeMgr.HideRecipeAll();
        recipeMgr.m_RecipeItemOnEffect[(int)m_eRecipe].PlayOnRecipe(RecipeItemOnEffect.E_EffectType.None);

        Gui_Refrigerator refrigerator = GuiManager.Instance.Find<Gui_Refrigerator>();
        refrigerator.ShowRecipe(m_eRecipe);

    }
}
