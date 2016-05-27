using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Cook_HotDog : CookBase
{

    public E_HotDogSeq m_CurrentState;
    const int c_MaxStdMaterialCount = 3;
    public CookingMaterial[] m_arrCookingMaterial = new CookingMaterial[c_MaxStdMaterialCount]; // 주제료 3개 
    
    public void Awake()
    {
        m_CurrentState = E_HotDogSeq.R000_010_00;

    }
    void FixedUpdate()
    {
        StateUpdatePlay();
    }

    void StateUpdatePlay()
    {
        switch (m_CurrentState)
        {
            case E_HotDogSeq.R000_010_00:// 재료 준비 0,1,2 재료 클릭 설정 상태 준비 
                PlaySeq_R000_010_00();
                break;
            case E_HotDogSeq.R000_010_10:// 재료 준비 0,1,2 재료 클릭 설정 상태 시작
                PlaySeq_R000_010_10();
                test_EffectOff();
                break;
            case E_HotDogSeq.R000_010_11:// 재료 준비 0,1,2 재료 클릭 설정 상태 중 대기 

                break;

            case E_HotDogSeq.R000_010_20: // 재료 준비 0,1,2 재료 클릭 설정 상태 리셋 시작
                PlaySeq_R000_010_20();
                break;
        }
    }

    Gui_Refrigerator _Gui_Refrigerator;
    bool PlaySeq_PreCheck()
    {
        if (_Gui_Refrigerator == null)
        {
            if (GuiManager.Instance == null || HelpManager.Instance == null)
                return false;

            _Gui_Refrigerator = GuiManager.Instance.Find<Gui_Refrigerator>();
        }

        if (_Gui_Refrigerator == null)
        {
            return false;
        }
        return true;
    }
    // 재료 준비 0,1,2 재료 클릭 설정 상태 준비 
    public void PlaySeq_R000_010_00()
    {
        if (PlaySeq_PreCheck() == false)
        {
            return;
        }
        // 도움말을 확인 하지 않았다면 0.5초마다 도움말 이 켜진다.  save data 확인 필요.
        float checkHelpTime = 0.5f; // save data 를 확인 하여 제설정 필요.
        HelpManager.Instance.SetHelpReadyTime(checkHelpTime);

        m_CurrentState = E_HotDogSeq.R000_010_10;// 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    }
    // 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    public void PlaySeq_R000_010_10()
    {
        if (PlaySeq_PreCheck() == false)
        {
            return;
        }

        HelpManager.Instance.SetOnPlayHelp(() =>
        {
            _Gui_Refrigerator.GetItem(0).transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            _Gui_Refrigerator.GetItem(1).transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            _Gui_Refrigerator.GetItem(2).transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        });
        

        m_CurrentState = E_HotDogSeq.R000_010_11;
    }

    public void PlaySeq_R000_010_20()
    {
        if (PlaySeq_PreCheck() == false)
        {
            return;
        }

        //_Gui_Refrigerator.GetItem(0).DORewind(); // DOKill(); //  DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        //_Gui_Refrigerator.GetItem(1).DORewind(); // .DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        //_Gui_Refrigerator.GetItem(2).DORewind(); //.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);

        m_CurrentState = E_HotDogSeq.R000_010_00;


        test_EffectOn();
    }

    void test_EffectOn()
    {
        // on test
        Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
        recipeMgr.m_RecipeItemOnEffect[0].AddCheckIx(0);
        recipeMgr.m_RecipeItemOnEffect[0].PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar);
    }
    void test_EffectOff()
    {
        Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
        recipeMgr.m_RecipeItemOnEffect[0].ClearCheck();
        recipeMgr.m_RecipeItemOnEffect[0].PlayOffRecipe();
    }

}
