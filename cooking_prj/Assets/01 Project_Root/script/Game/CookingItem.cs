using UnityEngine;
using System.Collections;
using DG.Tweening;


public class CookingItem : MonoBehaviour {
    public E_CookingItemGroupType m_eCookingItemGroupType;
    public E_CookingItemType m_eCookingItemType;
    public bool m_isActiveEvent = true;
    public Transform m_sprObject;
    public Transform m_sprCopyObject;
    public Transform m_ClickMoveTargetPos;
    public float m_MoveTime = 0.5f;
    public bool m_isPlayMove = false;

    public UISpriteAnimation m_StopWatch;

    public void PlayStopWatch()
    {
        m_StopWatch.gameObject.SetActive(true);
        m_StopWatch.Play();
    }
    //void Update()
    //{
    //    if (m_isActiveEvent)
    //    {
    //        PlayActive();
    //    }
    //    else
    //    {
    //        StopActive();
    //    }
    //}
    //Sequence _mySequence_PlayActive;
    //bool _playActive = false;
    //void PlayActive()
    //{
    //    if(_playActive == true)
    //    {
    //        return;
    //    }
    //    _playActive = true;

    //    _mySequence_PlayActive = DOTween.Sequence();
    //    _mySequence_PlayActive.Append(m_sprObject.DOScale(1.2f, 0.5f));
    //    _mySequence_PlayActive.SetLoops(-1, LoopType.Yoyo);

    //}
    //void StopActive()
    //{
    //    if (_playActive == false)
    //    {
    //        return;
    //    }
    //    _mySequence_PlayActive.Rewind();
    //    _playActive = false;
    //}

    public void MoveSpriteToTarget()
    {
        if (m_isPlayMove == true)
            return;
        m_isPlayMove = true;

        StartCoroutine(_MoveSpriteToTarget());
        
    }

    float m_toolEffectTime = 3.5f;
    IEnumerator _MoveSpriteToTarget()
    {
        if (m_sprCopyObject.gameObject.activeSelf == false)
        {
            m_sprCopyObject.gameObject.SetActive(true);
        }
        m_sprCopyObject.DOMove(m_ClickMoveTargetPos.position, m_MoveTime);
        yield return new WaitForSeconds(m_MoveTime);

        if(m_eCookingItemGroupType == E_CookingItemGroupType.CookingTool)
        {
            // Show effect
            // on test
            Gui_RecipeManager recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
            recipeMgr.m_RecipeItemOnEffect[0].AddCheckIx(0);
            recipeMgr.m_RecipeItemOnEffect[0].PlayOnRecipe(RecipeItemOnEffect.E_EffectType.ShowStar, m_ClickMoveTargetPos);

        }
        else
        {
            // test 도마에 올린다.
            m_sprCopyObject.position = m_ClickMoveTargetPos.position; // 해당 시간 이후 이동 했겠지만 혹시나 기기별 프레임 영향이 있을까봐.
            UISprite sprtmp = m_sprCopyObject.GetComponent<UISprite>();
            Gui_Worktops gui_worktops = GuiManager.Instance.Find<Gui_Worktops>();
            gui_worktops.m_arrRecipeWorktops[0].CopyItemOnChoppingBoard(sprtmp);
        }
        

        m_sprCopyObject.gameObject.SetActive(false);
        m_sprCopyObject.position = m_sprObject.position;

        m_isPlayMove = false;
    }
}
