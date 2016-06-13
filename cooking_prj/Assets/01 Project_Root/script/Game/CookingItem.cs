using UnityEngine;
using System.Collections;
using DG.Tweening;


public class CookingItem : MonoBehaviour {
    public E_CookingItemGroupType m_eCookingItemGroupType;
    public E_CookingItemType m_eCookingItemType;
    public bool m_isActiveEvent = false;
    public Transform m_sprObject;
    public Transform m_sprCopyObject;
    public Transform m_ClickMoveTargetPos;
    public float m_MoveTime = 0.5f;
    public bool m_isPlayMove = false;

    public UISpriteAnimation m_StopWatch;
    public bool m_isPlayStopWatch = false;

    public GameObject m_CookSlot = null;
    public Transform m_CookSlotPos; // spawn 에 사용.

    string m_strformat_StopWatchAni = "{0}{1}";
    System.Action _OnComplet_Stopwatch = null;
    public void ActiveStopwatch(System.Action call)
    {
        _OnComplet_Stopwatch = call;
        m_StopWatch.gameObject.SetActive(true);
        m_StopWatch.enabled = false; // auto play 대기.
        m_StopWatch.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
    public void PlayStopWatch()
    {
        m_StopWatch.transform.DORewind();
        m_StopWatch.enabled = true;
        // m_StopWatch.gameObject.SetActive(true);
        // m_StopWatch.GetComponent<UISprite>().spriteName = string.Format(m_strformat_StopWatchAni, m_StopWatch.namePrefix, "0"); // 처음 부터
        m_StopWatch.ResetToBeginning();
        m_StopWatch.Play();
        m_isPlayStopWatch = true;
    }
    void Update()
    {
        if(m_isActiveEvent == false)
        {
            return;
        }

        if (m_isPlayStopWatch == true)
        {
            m_isPlayStopWatch = m_StopWatch.isPlaying;
            if(m_isPlayStopWatch == false)
            {
                // OnComplet Stopwatch // m_StopWatch.ResetToBeginning();
                if(_OnComplet_Stopwatch != null)
                {
                    _OnComplet_Stopwatch();
                }
            }
        }
    }

    public void SetActiveEvent(bool b)
    {
        m_isActiveEvent = b;
    }
    public void SetActiveEvent(bool b, bool b_effect)
    {
        m_isActiveEvent = b;
        if(b_effect == true && m_sprObject != null)
        {
            if(m_isActiveEvent == false)
            {
                m_sprObject.transform.DORewind();
            }else
            {
                m_sprObject.transform.DORewind();
                m_sprObject.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }

    public void MoveSpriteToTarget()
    {
        if (m_isPlayMove == true || m_isActiveEvent == false)
            return;
        m_isPlayMove = true;

        StartCoroutine(_MoveSpriteToTarget());
        
    }

    float m_toolEffectTime = 3.5f;
    IEnumerator _MoveSpriteToTarget()
    {
        // Ngui 버튼 이밴트 락을 걸어 목표지점 까지 도착 할때 까지 잠시 막아 놓아 봄.  멀티 터치가 않되어 버벅이는것 같아 보류함.
        // 투명 레이어로 막을까? UICamera.current. 에서 핸들 할까?  
//        GuiManager.Instance.GetBackUICamera().enabled = false;

        CookingItem cook_item_tmp;
        int recipeIx = (int) CookManager.Instance.m_CurrentRecipe;
        if (m_sprCopyObject.gameObject.activeSelf == false)
        {
            m_sprCopyObject.gameObject.SetActive(true);
        }
        m_sprCopyObject.DOMove(m_ClickMoveTargetPos.position, m_MoveTime);
        yield return new WaitForSeconds(m_MoveTime);

        
        m_sprCopyObject.gameObject.SetActive(false);
        m_sprCopyObject.position = m_sprObject.position;

        m_isPlayMove = false;

        CookManager.Instance.CheckCurrentCookingItem(this); 

    }
}
