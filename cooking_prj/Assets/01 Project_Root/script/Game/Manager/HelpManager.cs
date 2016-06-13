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
    public float m_DefaultReadyTime = 10f;
    public float m_fHelpReadyTime = 10f;
    public float m_CurrentReadyTime;
    public bool m_isPlayingHelp = false;
    public System.Action m_OnPlayHelp = null;

    Gui_Worktops _worktops = null;
    Gui_ToolsInventory _toolsInven = null;
    Gui_Refrigerator _refrigerator = null;
    Gui_RecipeManager _recipeMgr = null;

    
    public void SetHelpReadyTime()
    {
        m_fHelpReadyTime = m_DefaultReadyTime;
        SetCurrentReadyTime();
    }
    public void SetHelpReadyTime(float t)
    {
        m_fHelpReadyTime = t;
        SetCurrentReadyTime();
    }
    public void UpdateActiveHelp()
    {
        m_isPlayingHelp = false;
        m_CurrentReadyTime = m_fHelpReadyTime;
    }
    void SetCurrentReadyTime()
    {
        m_isPlayingHelp = false;
        m_CurrentReadyTime = m_fHelpReadyTime;
    }
    
	// Use this for initialization
	void Start () {
        CheckSetup();

        SetCurrentReadyTime();

    }
    void CheckSetup()
    {
        if (_worktops == null)
        {
            _worktops = GuiManager.Instance.Find<Gui_Worktops>();
        }
        if (_toolsInven == null)
        {
            _toolsInven = GuiManager.Instance.Find<Gui_ToolsInventory>();
        }
        if (_refrigerator == null)
        {
            _refrigerator = GuiManager.Instance.Find<Gui_Refrigerator>();
        }
        if (_recipeMgr == null)
        {
            _recipeMgr = GuiManager.Instance.Find<Gui_RecipeManager>();
        }
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
                OnPlayHelp();
                SetCurrentReadyTime(); // m_isPlayingHelp = false 하지만,
                m_isPlayingHelp = true;
            }
        }
	}

    // 
    void OnPlayHelp()
    {
        // 재료, 도구, 설비에서 item active 확인 하여 스프라이트 효과 플레이 함.
        // 재료, 도구, 설비 를 설정 하고,
        _refrigerator.ShowHelp();
        _toolsInven.ShowHelp();
        _worktops.ShowHelp();


        // 공통 도움 로직 이외에 설정 하고자 한경우.
        if (m_OnPlayHelp != null)
        {
            m_OnPlayHelp();
        }
    }
}
