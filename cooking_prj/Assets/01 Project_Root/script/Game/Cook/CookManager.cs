using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookManager : MonoBehaviour {

    #region Singleton

    private static CookManager _instance = null;

    public static CookManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion Singleton

    public List<CookBase> _cookEntityPools = new List<CookBase>();

    public E_RecipeEnum m_CurrentRecipe;
    public CookingItem m_CurrentCookingItem;  // 지금 처리된 아이템 
    System.Action m_OnCompleteCookingItem = null;

    public void DelayAction(float wait_time, System.Action call)
    {
        StartCoroutine(_DelayAction(wait_time, call));
    }
    IEnumerator _DelayAction(float wait_time, System.Action call)
    {
        yield return new WaitForSeconds(wait_time);
        if(call != null)
        {
            call();
        }
    }


    protected void Awake()
    {
        _instance = this;
 //       ChangeCurrentRecipe(E_RecipeEnum.Hotdog);
    }
    void Start()
    {
        ChangeCurrentRecipe(E_RecipeEnum.Hotdog, false);
    }
    protected void OnDestroy()
    {
        StopAllCoroutines();

        _instance = null;
    }

    public T Find<T>() where T : CookBase
    {
        for (int i = 0; i < _cookEntityPools.Count; i++)
        {
            if (_cookEntityPools[i].gameObject.name == typeof(T).ToString())
            {
                return _cookEntityPools[i] as T;
            }
        }

        return null;
    }

    public CookBase GetCurrentCook()
    {
        for (int i = 0; i < _cookEntityPools.Count; i++)
        {
            if (_cookEntityPools[i].m_RecipeIx == m_CurrentRecipe)
            {
                return _cookEntityPools[i];
            }
        }

        return null;
    }

    public void ChangeCurrentRecipe(E_RecipeEnum e, bool b_show_recipe = true)
    {
        m_CurrentRecipe = e;

        if(m_CurrentRecipe == E_RecipeEnum.Hotdog)
        {
            // 도움을 확인 하지 않았다면 0.5초마다 도움말 이 켜진다.  save data 확인 필요.
            float checkHelpTime = 0.5f; // save data 를 확인 하여 제설정 필요.
            HelpManager.Instance.SetHelpReadyTime(checkHelpTime);
        }else
        {
            HelpManager.Instance.SetHelpReadyTime(); // default time 설정.
        }

        if(b_show_recipe == true)
        {
            // 레시피를 보여주고
            Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
            recipeMgr.HideRecipeAll();
            recipeMgr.m_RecipeItemOnEffect[(int)m_CurrentRecipe].PlayOnRecipe(RecipeItemOnEffect.E_EffectType.None);

        }

        // 재료, 도구, 설비 를 설정 하고,
        Gui_Refrigerator refrigerator = GuiManager.Instance.Find<Gui_Refrigerator>();
        refrigerator.ShowRecipe(m_CurrentRecipe);

        Gui_ToolsInventory inven = GuiManager.Instance.Find<Gui_ToolsInventory>();
        inven.ShowRecipe(m_CurrentRecipe);
        Gui_Worktops worktops = GuiManager.Instance.Find<Gui_Worktops>();
        worktops.ShowRecipe(m_CurrentRecipe);

    }

    public void CheckCurrentCookingItem(CookingItem itm)
    {
        m_CurrentCookingItem = itm;

        GetCurrentCook().CheckPlayedCookingItem(itm);
    }
}
