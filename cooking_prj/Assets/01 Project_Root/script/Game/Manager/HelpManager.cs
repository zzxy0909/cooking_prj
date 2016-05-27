using UnityEngine;
using System.Collections;

public class HelpManager : MonoBehaviour {

    #region Singleton

    private static HelpManager _instance = null;

    public static HelpManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion Singleton
    void Awake()
    {
        _instance = this;

        SetCurrentReadyTime();

    }

    public float m_fHelpReadyTime = 10f;
    public float m_CurrentReadyTime;
    public bool m_isPlayingHelp = false;
    public System.Action OnPlayHelp = null;

    public void SetHelpReadyTime(float t)
    {
        m_fHelpReadyTime = t;
        SetCurrentReadyTime();
    }
    public void SetOnPlayHelp(System.Action call)
    {
        OnPlayHelp = call;
        SetCurrentReadyTime();
    }

    void SetCurrentReadyTime()
    {
        m_isPlayingHelp = false;
        m_CurrentReadyTime = m_fHelpReadyTime;
    }
    
	// Use this for initialization
	void Start () {
        SetCurrentReadyTime();

    }
	
	// Update is called once per frame
	void Update () {
	
        if(m_isPlayingHelp == false)
        {
            if(Input.GetMouseButtonDown(0) == true)
            {
                SetCurrentReadyTime();
            }

            m_CurrentReadyTime -= Time.deltaTime;
            if(m_CurrentReadyTime <= 0)
            {
                if(OnPlayHelp != null)
                {
                    OnPlayHelp();
                }
                SetCurrentReadyTime(); // m_isPlayingHelp = false 하지만,
                m_isPlayingHelp = true;
            }
        }
	}
}
