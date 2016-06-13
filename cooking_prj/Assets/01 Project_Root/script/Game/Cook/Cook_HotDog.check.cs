using UnityEngine;
using System.Collections;
using DG.Tweening;

public partial class Cook_HotDog : CookBase
{

    public bool m_CheckPoint_R010 = false; // 야채
    public bool m_CheckPoint_R020 = false; // 빵
    public bool m_CheckPoint_R030 = false; // 소시지
    public bool m_CheckPoint_R041 = false; // 구운빵 접시에올리고 소스 준비. 

    void Set_CheckPoint(int ix)
    {
        switch(ix)
        {
            case 0:
                m_CheckPoint_R010 = true;
                break;
            case 1:
                m_CheckPoint_R020 = true;
                break;
            case 2:
                m_CheckPoint_R030 = true;
                break;
            case 3:
                m_CheckPoint_R041 = true;
                break;
        }
    }

}
