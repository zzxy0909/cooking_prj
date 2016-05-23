using UnityEngine;
using System;
using System.Collections;

public class TimeProgress : MonoBehaviour {
    public UISlider m_UISlider;
    public string m_ProgressTime = "00:00:01";
    public TimeSpan m_TimeSpan;
    public double m_dTimeValue;
    public bool m_isPlay = false;
    public bool m_loop = false;
    public System.Action m_OnComplet;

    public bool m_PlayTimeSpan = false;

    public void SetTimeSpan_StartTime()
    {
        m_TimeSpan = TimeSpan.Parse(m_ProgressTime);
        m_dTimeValue = m_TimeSpan.TotalSeconds;
    }
    public void SetTimeSpan(string str)
    {
        m_ProgressTime = str;
        m_TimeSpan = TimeSpan.Parse(m_ProgressTime);
        m_dTimeValue = m_TimeSpan.TotalSeconds;
    }
    public void SetTimeSpan(long tick)
    {
        m_TimeSpan = new TimeSpan(tick);
        m_dTimeValue = m_TimeSpan.TotalSeconds;
    }

    // Use this for initialization
    void Start () {

        PlayTimeSpan();

    }

    public void PlayTimeSpan()
    {
        m_PlayTimeSpan = false;
        SetTimeSpan_StartTime();
        m_isPlay = true;
    }

	// Update is called once per frame
	void Update () {
	
        if(m_isPlay)
        {
            m_dTimeValue -= Time.deltaTime;
            if(m_dTimeValue < 0)
            {
                m_isPlay = false;
                m_UISlider.value = 1;
                if(m_OnComplet != null)
                {
                    m_OnComplet();
                }
                if(m_loop == true)
                {
                    PlayTimeSpan();
                }
            }

            m_UISlider.value = 1 - (float)(m_dTimeValue / m_TimeSpan.TotalSeconds);
        }
        if(m_PlayTimeSpan)
        {
            PlayTimeSpan();
        }
	}
}
