using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CookingEventItemBase : MonoBehaviour {
    public int m_RecipeIx;
    public bool m_isActiveEvent = true;
    public Transform m_sprObject;
    public Transform m_sprCopyObject;
    public Transform m_ClickMoveTargetPos;
    public float m_MoveTime = 0.5f;
    public bool m_isPlayMove = false;

    void Update()
    {
        if(m_isActiveEvent)
        {
            PlayActive();
        }else
        {
            StopActive();
        }
    }
    Sequence _mySequence_PlayActive;
    bool _playActive = false;
    void PlayActive()
    {
        if(_playActive == true)
        {
            return;
        }
        _playActive = true;

        _mySequence_PlayActive = DOTween.Sequence();
        _mySequence_PlayActive.Append(m_sprObject.DOScale(1.2f, 0.5f));
        _mySequence_PlayActive.SetLoops(-1, LoopType.Yoyo);
        
    }
    void StopActive()
    {
        if (_playActive == false)
        {
            return;
        }
        _mySequence_PlayActive.Rewind();
        _playActive = false;
    }

	public void MoveSpriteToTarget()
    {
        if (m_isPlayMove == true)
            return;
        StartCoroutine(_MoveSpriteToTarget());
        
    }
	
    IEnumerator _MoveSpriteToTarget()
    {
        if (m_sprCopyObject.gameObject.activeSelf == false)
        {
            m_sprCopyObject.gameObject.SetActive(true);
        }
        m_sprCopyObject.DOMove(m_ClickMoveTargetPos.position, m_MoveTime);
        yield return new WaitForSeconds(m_MoveTime);

        m_sprCopyObject.gameObject.SetActive(false);
        m_sprCopyObject.position = m_sprObject.position;


    }

    void SpawnSprite()
    {
        switch ((E_RecipeEnum)m_RecipeIx)
        {
            case E_RecipeEnum.Hotdog:
            case E_RecipeEnum.Hamburger:

                break;
        }
    }

}
