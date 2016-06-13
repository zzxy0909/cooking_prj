using UnityEngine;
using System.Collections;
using DG.Tweening;

public partial class Cook_HotDog : CookBase
{

    public E_HotDogSeq m_CurrentState;
    const int c_MaxStdMaterialCount = 3;
    public CookingMaterial[] m_arrCookingMaterial = new CookingMaterial[c_MaxStdMaterialCount]; // 주제료 

    public GameObject m_sprProcessed_1_1;
    public GameObject m_sprProcessed_1_2;
    public GameObject m_sprProcessed_1_3;
    public GameObject m_sprProcessed_1_4_1;
    Gui_Worktops _worktops = null;
    Gui_ToolsInventory _toolsInven = null;
    Gui_Refrigerator _refrigerator = null;
    Gui_RecipeManager _recipeMgr = null;

    public void Awake()
    {
        m_CurrentState = E_HotDogSeq.R000_010_00;

    }
    void Start()
    {
        if(_worktops == null)
        {
            _worktops = GuiManager.Instance.Find<Gui_Worktops>();
        }
        if(_toolsInven == null)
        {
            _toolsInven = GuiManager.Instance.Find<Gui_ToolsInventory>();
        }
        if(_refrigerator == null)
        {
            _refrigerator = GuiManager.Instance.Find<Gui_Refrigerator>();
        }
        if (_recipeMgr == null)
        {
            _recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
        }
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
                break;
            case E_HotDogSeq.R000_010_11:// 재료 준비 0,1,2 재료 클릭 설정 상태 중 대기 

                break;
            case E_HotDogSeq.R000_020_10:// 첫페이지 시작. 0개 이상 완료. 조리대에 재료 놓여짐. 
                // 루핑 체크 않됨. --> SetFirstPageStart() 할때 체크 하게 변경.  PlaySeq_R000_020_10(); // 이후 처리 - 첫페이 완료 되었는 가 확인 등...
                break;
            case E_HotDogSeq.R000_010_20: // 재료 준비 0,1,2 재료 클릭 설정 상태 리셋 시작
                PlaySeq_R000_010_20();
                break;
            default:
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
        
        m_CurrentState = E_HotDogSeq.R000_010_10;// 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    }
    // 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    public void PlaySeq_R000_010_10()
    {
        if (PlaySeq_PreCheck() == false)
        {
            return;
        }

        // 도구중 해당 타입들을 끈다.
        _Gui_Refrigerator.SetAll_ActiveEventType(E_CookingItemType.bread, true, true); // DORewind effect.
        _Gui_Refrigerator.SetAll_ActiveEventType(E_CookingItemType.sausage, true, true); // DORewind effect.
 
        m_CurrentState = E_HotDogSeq.R000_010_11;
    }

    public void PlaySeq_R000_010_20()
    {
        if (PlaySeq_PreCheck() == false)
        {
            return;
        }

        _Gui_Refrigerator.SetAll_ActiveEventType(E_CookingItemType.bread, false, true); // DORewind effect.
        _Gui_Refrigerator.SetAll_ActiveEventType(E_CookingItemType.sausage, false, true); // DORewind effect.

        m_CurrentState = E_HotDogSeq.R000_010_00;

//        test_EffectOn();
    }

    //void test_EffectOn()
    //{
    //    // on test
    //    Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
    //    recipeMgr.m_RecipeItemOnEffect[0].AddCheckIx(0);
    //    recipeMgr.m_RecipeItemOnEffect[0].PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar);
    //}
    //void test_EffectOff()
    //{
    //    Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
    //    recipeMgr.m_RecipeItemOnEffect[0].ClearCheck();
    //    recipeMgr.m_RecipeItemOnEffect[0].PlayOffRecipe();
    //}

}
