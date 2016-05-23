using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Gui_HotDog : GuiBase
{
    public E_HotDogSeq m_CurrentState; 

    public override void SetInspactor_InitTransList()
    {
    }
    
	public void Awake()
	{
        m_CurrentState = E_HotDogSeq.S01_0_Material_preparation;

    }

    public void OnEnable()
	{
        Debug.Log("~~~~~~~~~~~~~~~~ _OnEnable !");
        switch(m_CurrentState)
        {
            case E_HotDogSeq.S01_0_Material_preparation:
                PlaySeq_S01_0();
                break;
        }
    }
    
    Gui_Refrigerator _Gui_Refrigerator;
    // 처음 재료 선택 상태.
    bool _isPlayedSeq_S01_0 = false; // _isPlayedSeq_S01_0 플레이 한것 체크;
    public void PlaySeq_S01_0()
    {
        if(_Gui_Refrigerator == null)
        {
            _Gui_Refrigerator = GuiManager.Instance.Find<Gui_Refrigerator>();
        }

        _Gui_Refrigerator.GetItem(0).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        _Gui_Refrigerator.GetItem(1).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
        _Gui_Refrigerator.GetItem(2).DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

}
