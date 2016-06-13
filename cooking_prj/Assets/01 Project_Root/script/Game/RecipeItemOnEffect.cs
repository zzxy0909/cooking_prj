using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class RecipeItemOnEffect : MonoBehaviour {
    public enum E_EffectType
    {
        None,
        ShowStar,
    }

    public Transform m_ViewRoot;
    public Transform[] m_CheckItem;
    public List<int> m_lstCheckIx;
    public ParticleSystem m_StarPartsEffect;
    public ParticleSystem m_coinEffect;
    public Transform m_coinEffect_target;

    // Use this for initialization
    void Start () {
        ClearCheck();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ClearCheck()
    {
        m_lstCheckIx.Clear();
        for (int i = 0; i < m_CheckItem.Length; i++)
        {
            if (m_CheckItem[i].gameObject.activeSelf == true)
            {
                m_CheckItem[i].DOKill();
                m_CheckItem[i].gameObject.SetActive(false);
            }
                
        }
    }
    public void AddCheckIx(int ix)
    {
        if(m_lstCheckIx.Contains(ix) == false)
        {
            m_lstCheckIx.Add(ix);
        }
        
    }
    public void HideRecipe()
    {
        m_ViewRoot.gameObject.SetActive(false);
    }
    public void PlayOffRecipe()
    {
        // 닫을때 효과는 느린 반응 느껴짐.
        m_ViewRoot.gameObject.SetActive(false);

        //float punch_time = 0.5f;
        ////        if(m_ViewRoot.gameObject.activeSelf == false)
        //{
        //    // m_ViewRoot.localScale = Vector3.zero;
        //    m_ViewRoot.gameObject.SetActive(true);
        //    m_ViewRoot.DOPunchScale(Vector3.zero, punch_time, 5);
        //}
        //StartCoroutine(_DelayPlayOffEffect(punch_time));

        // StopCoroutine("_SeqPlayRecipeEffect");
        // 강력하게 모든 코루틴 종료.
        StopAllCoroutines();
    }
    IEnumerator _DelayPlayOffEffect(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        m_ViewRoot.gameObject.SetActive(false);
    }

    public float m_fShowDuration = 2f;
    float m_fShowElastic = 1f;
    float m_Delay_time = 0.1f;
    Vector3 m_StartShowScale = new Vector3(0.9f, 0.9f, 0.9f);
    Ease m_ShowEaseType = Ease.OutElastic;
    public void PlayOnRecipe(E_EffectType etype, Transform effectPos = null)
    {
        
//        if(m_ViewRoot.gameObject.activeSelf == false)
        {
            // m_ViewRoot.localScale = Vector3.zero;
            
        }
        StopCoroutine("_SeqPlayRecipeEffect");
        StartCoroutine(_SeqPlayRecipeEffect( etype, effectPos));
        
    }
    public float m_coin_upEffect_time = 1.5f;
    IEnumerator _SeqPlayRecipeEffect(E_EffectType etype, Transform effectPos = null)
    {
        float punch_time = 0.5f;
        if(etype == E_EffectType.ShowStar)
        {
            if(m_lstCheckIx.Count > 0)
            {
                Vector3 tmpVec;
                if (effectPos == null)
                {
                    tmpVec = m_CheckItem[m_lstCheckIx[m_lstCheckIx.Count - 1]].position;
                    
                }else
                {
                    tmpVec = effectPos.position;
                }
                m_coinEffect.transform.position = m_StarPartsEffect.transform.position = new Vector3(tmpVec.x, tmpVec.y, m_StarPartsEffect.transform.position.z);
                m_StarPartsEffect.Stop();
                m_StarPartsEffect.Play();

                m_coinEffect.gameObject.SetActive(true);
                m_coinEffect.Play();

                m_coinEffect.transform.DOMove(m_coinEffect_target.position,  m_coin_upEffect_time); // m_Delay_time + punch_time > 도착후 대기 시간.

                CookManager.Instance.DelayAction(m_coin_upEffect_time + m_Delay_time + punch_time,
                    () =>
                    {
                        m_coinEffect.gameObject.SetActive(false);
                    });

                yield return new WaitForSeconds(m_Delay_time);
            }
            
        }

        m_ViewRoot.localScale = m_StartShowScale;
        m_ViewRoot.gameObject.SetActive(true);
        m_ViewRoot.DOScale(m_fShowElastic, punch_time).SetEase(m_ShowEaseType); 
        yield return new WaitForSeconds(punch_time);
        
        if(m_lstCheckIx.Count > 0)
        {
            for (int i = 0; i < m_lstCheckIx.Count; i++)
            {
                // if (m_CheckItem[m_lstCheckIx[i]].gameObject.activeSelf == false)
                {
                    m_CheckItem[m_lstCheckIx[i]].gameObject.SetActive(true);
                    m_CheckItem[m_lstCheckIx[i]].DORewind();
                    m_CheckItem[m_lstCheckIx[i]].localScale = Vector3.one;
                }

            }
            m_CheckItem[m_lstCheckIx[m_lstCheckIx.Count - 1]].DORewind();
            m_CheckItem[m_lstCheckIx[m_lstCheckIx.Count - 1]].DOScale(1.2f, 1f).SetEase(Ease.InElastic).SetLoops(-1, LoopType.Yoyo);
        }

        // 그로벌 비헤이비어에 마낀다.
        //if (m_coinEffect.gameObject.activeSelf == true)
        //{
        //    yield return new WaitForSeconds(m_coin_upEffect_time);
        //    m_coinEffect.gameObject.SetActive( false);
        //}

        if (etype == E_EffectType.ShowStar)
        {

            yield return new WaitForSeconds(m_fShowDuration);
            PlayOffRecipe();
        }
    }
}
