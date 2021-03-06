﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Gui_HotDog : GuiBase
{
    public E_HotDogSeq m_CurrentState;
    const int c_MaxStdMaterialCount = 3;
    public CookingMaterial[] m_arrCookingMaterial = new CookingMaterial[c_MaxStdMaterialCount]; // 주제료 3개 

    public override void SetInspactor_InitTransList()
    {
    }
    
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
        switch(m_CurrentState)
        {
            case E_HotDogSeq.R000_010_00:// 재료 준비 0,1,2 재료 클릭 설정 상태 준비 
                PlaySeq_R000_010_00();
                break;
            case E_HotDogSeq.R000_010_10:// 재료 준비 0,1,2 재료 클릭 설정 상태 시작
                PlaySeq_R000_010_10();
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


        //_Gui_Refrigerator.GetItem(0).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        //_Gui_Refrigerator.GetItem(1).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        //_Gui_Refrigerator.GetItem(2).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);

        m_CurrentState = E_HotDogSeq.R000_010_10;// 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    }

    // 재료 준비 0,1,2 재료 클릭 설정 상태 시작 
    public void PlaySeq_R000_010_10()
    {
        if(PlaySeq_PreCheck() == false)
        {
            return;
        }

        //_Gui_Refrigerator.GetItem(0).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        //_Gui_Refrigerator.GetItem(1).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        //_Gui_Refrigerator.GetItem(2).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);

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

    }
    
}
