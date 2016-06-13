using UnityEngine;
using System.Collections;
using DG.Tweening;

public partial class Cook_HotDog : CookBase
{

    public bool m_isFirstPageStart = false;
    // R000_020_10 첫페이지 시작. 0개 이상 완료. 조리대에 재료 놓여짐.
    public void SetFirstPageStart()
    {
        // 여러번 호출 되더 라도 한번만 실행.
        if (m_isFirstPageStart == true)
        {
            return;
        }
        m_CurrentState = E_HotDogSeq.R000_020_10;

    }
    // 이후 처리 - 첫페이 완료 되었는 가 확인 등...
    void PlaySeq_R000_020_10()
    {

    }
    public override void CheckPlayedCookingItem(CookingItem itm)
    {
        CookingItem item_tmp;
        // int recipeIx = (int)CookManager.Instance.m_CurrentRecipe;
        int recipeIx = (int)E_RecipeEnum.Hotdog;
        bool is_processOK = true;

        if (itm.m_eCookingItemGroupType == E_CookingItemGroupType.CookingMatrial)
        {
            // itm.m_sprCopyObject.position = itm.m_ClickMoveTargetPos.position; // 해당 시간 이후 이동 했겠지만 혹시나 기기별 프레임 영향이 있을까봐.
            UISprite sprtmp = itm.m_sprCopyObject.GetComponent<UISprite>();
            Gui_Worktops gui_worktops = GuiManager.Instance.Find<Gui_Worktops>();

            switch (itm.m_eCookingItemType)
            {
                case E_CookingItemType.vegetable:
                    // 도마에 올린다.
                    // gui_worktops.m_arrRecipeWorktops[recipeIx].CopyItemOnChoppingBoard(sprtmp);
                    is_processOK = gui_worktops.m_arrRecipeWorktops[recipeIx].CopyItemOnItemType(sprtmp, E_CookingItemType.ChoppingBoard1, itm);
                    break;
                case E_CookingItemType.sausage:
                    // 팬에 없다면 올린다.
                    is_processOK = gui_worktops.m_arrRecipeWorktops[recipeIx].CopyItemOnItemType(sprtmp, E_CookingItemType.Pan1, itm);
                    break;
                case E_CookingItemType.bread:
                    // 팬에 올린다.
                    is_processOK = gui_worktops.m_arrRecipeWorktops[recipeIx].CopyItemOnItemType(sprtmp, E_CookingItemType.Pan1, itm);

                    //gui_worktops.m_arrRecipeWorktops[recipeIx].CopyItemOnPan1(sprtmp);

                    //// 오븐에 올린다.
                    //item_tmp = gui_worktops.m_arrRecipeWorktops[recipeIx].CopyItemOnOven1(sprtmp);
                    //item_tmp.SetActiveEvent(true);
                    //// if(cook_item_tmp.m_StopWatch != null)
                    //{
                    //    item_tmp.m_sprObject = item_tmp.m_StopWatch.transform;

                    //}
                    //// 시계설정.
                    //item_tmp.ActiveStopwatch(() =>
                    //{
                    //    Debug.Log("~~~~~~~~~~~~~ Stopwatch Play End.");
                    //    item_tmp.m_sprObject = item_tmp.m_CookSlot.transform;
                    //    // Show effect
                    //    // on test
                    //    Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
                    //    recipeMgr.m_RecipeItemOnEffect[recipeIx].AddCheckIx(1);
                    //    recipeMgr.m_RecipeItemOnEffect[recipeIx].PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar, itm.m_ClickMoveTargetPos);

                    //    Set_CheckPoint(1);

                    //    // 오븐에 구운 빵 보이기.
                    //    _worktops.m_arrRecipeWorktops[(int)E_RecipeEnum.Hotdog].SpawnItemOnItemType(m_sprProcessed_1_2, E_CookingItemType.Oven1);

                    //});
                    //item_tmp.PlayStopWatch();
                    break;

            }
        }else if(itm.m_eCookingItemGroupType == E_CookingItemGroupType.Processed)
        {
            // 접 시에 있는 것에 따라 처리 한다.
            // 접시에 아무것도 없다면, 그냥 올린다.
        }

        if(is_processOK == false)
        {
            // 전달 처리 않됨.
            return;
        }


        if (itm.m_eCookingItemGroupType == E_CookingItemGroupType.CookingMatrial)
        {
            itm.m_sprObject.transform.DORewind(); // scale 효과 멈추고.
            itm.SetActiveEvent(false); // 이밴트 끈다.

            SetFirstPageStart(); // R000_020_10 첫페이지 시작.

            // 해당 도구의 이밴트를 킨다.
            switch (itm.m_eCookingItemType)
            {
                case E_CookingItemType.vegetable: // 야채 이면 칼 찾아 on

                    item_tmp = _toolsInven.GetItem(E_CookingItemType.knife1);
                    if (item_tmp)
                    {
                        item_tmp.SetActiveEvent(true);
                        HelpManager.Instance.UpdateActiveHelp(); // help 갱신.
                    }
                    else
                    {
                        Debug.Log("~~~~~~~~~~~~~~~ error _worktops.GetItem(E_CookingItemType.ChoppingBoard1) == null");
                    }
                    break;
                case E_CookingItemType.bread: // 빵 도 팬 뒤집개 찾아 on
                case E_CookingItemType.sausage: // 소시지 이면 뒤집개 찾아 on
                    item_tmp = _toolsInven.GetItem(E_CookingItemType.spatula1);
                    if (item_tmp)
                    {
                        item_tmp.SetActiveEvent(true);
                        HelpManager.Instance.UpdateActiveHelp(); // help 갱신.
                    }
                    else
                    {
                        Debug.LogError("~~~~~~~~~~~~~~~ error _toolsInven.GetItem(E_CookingItemType.spatula1) == null");
                    }
                    break;
            }
        }
        else if (itm.m_eCookingItemGroupType == E_CookingItemGroupType.CookingTool)
        {
            // itm.m_sprObject.transform.DORewind(); // scale 효과 멈추고.
            // itm.SetActiveEvent(false); // 이밴트 끈다.


            // 해당 도구의 이밴트를 킨다.
            switch (itm.m_eCookingItemType)
            {
                case E_CookingItemType.knife1:
                case E_CookingItemType.knife2:
                case E_CookingItemType.knife3:
                    // 도구중 해당 타입들을 끈다.
                    _toolsInven.SetAll_ActiveEventType(E_CookingItemType.knife1, false, true); // DORewind effect.
                    _toolsInven.SetAll_ActiveEventType(E_CookingItemType.knife2, false, true); // DORewind effect.
                    _toolsInven.SetAll_ActiveEventType(E_CookingItemType.knife3, false, true); // DORewind effect.

                    this._recipeMgr.AddCheckIx(0);
                    Set_CheckPoint(0);

                    _recipeMgr.PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar, itm.m_ClickMoveTargetPos);
                    // 완료 후 도마 위 손질 한 것으로 나오개 한다.
                    _worktops.m_arrRecipeWorktops[recipeIx].SpawnItemOnItemType(m_sprProcessed_1_1, E_CookingItemType.ChoppingBoard1);

                    break;
                case E_CookingItemType.spatula1:
                    // 도구중 해당 타입들을 끈다.
                    _toolsInven.SetAll_ActiveEventType(E_CookingItemType.spatula1, false, true); // DORewind effect.
                    _toolsInven.SetAll_ActiveEventType(E_CookingItemType.spatula2, false, true); // DORewind effect.
                    _toolsInven.SetAll_ActiveEventType(E_CookingItemType.spatula3, false, true); // DORewind effect.

                    // 팬 위의 제품이. 빵인가? 소시지인가?
                    item_tmp = _worktops.GetItem(E_CookingItemType.Pan1).m_CookSlot.GetComponent<CookingItem>();
                    if(item_tmp.m_eCookingItemType == E_CookingItemType.bread)
                    {
                        this._recipeMgr.AddCheckIx(1);
                        Set_CheckPoint(1);
                        _recipeMgr.PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar, itm.m_ClickMoveTargetPos);
                        _worktops.m_arrRecipeWorktops[recipeIx].SpawnItemOnItemType(m_sprProcessed_1_2, E_CookingItemType.Pan1);
                    }
                    else if (item_tmp.m_eCookingItemType == E_CookingItemType.sausage)
                    {
                        this._recipeMgr.AddCheckIx(2);
                        Set_CheckPoint(2);
                        _recipeMgr.PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar, itm.m_ClickMoveTargetPos);
                        _worktops.m_arrRecipeWorktops[recipeIx].SpawnItemOnItemType(m_sprProcessed_1_3, E_CookingItemType.Pan1);
                    }
                    else 
                    {
                        Debug.Log("~~~~~~~~~~~~~~~~~~~~~ 팬 위의 제품이. 빵인가? 소시지인가? Error !");
                    }

                    // 팬 의 이밴트 설정.
                    item_tmp = _worktops.GetItem(E_CookingItemType.Pan1);
                    item_tmp.m_sprObject = item_tmp.m_CookSlot.transform;
                    item_tmp.m_sprCopyObject = item_tmp.m_CookSlot.transform;

                    item_tmp.SetActiveEvent(true);
                    HelpManager.Instance.UpdateActiveHelp(); // help 갱신.

                    break;

            }
        }
    }
}
