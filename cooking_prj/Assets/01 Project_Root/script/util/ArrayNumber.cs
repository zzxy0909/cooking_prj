using UnityEngine;
using System.Collections;
using System.Text;

[System.Serializable]
public class ArrayNumber
{
    const int _MaxArray = 6;
    public float[] m_arrNumber = new float[_MaxArray];
    public static string[] m_Unit = new string[] { "", "만", "억", "조", "경", "해" };
 

    public void Clear()
    {
        for(int i=0; i<_MaxArray; i++)
        {
            m_arrNumber[i] = 0;
        }
    }

    string _getTextFullFormat = " {0:####}{1}";
    public string GetTextFullValue()
    {
        StringBuilder sb = new StringBuilder();
        for(int i = _MaxArray-1; i>0; i--)
        {
            if(m_arrNumber[i] > 0)
            {
                sb.AppendFormat(_getTextFullFormat, m_arrNumber[i], m_Unit[i]);
            }
        }
        sb.AppendFormat(_getTextFullFormat, m_arrNumber[0], m_Unit[0]); // 마지막은 무조건 이라도 출력.
        return sb.ToString();
    }

    string _getTextUpperFormat = " {0:###0.##}{1}";
    public string GetTextUpperValue()
    {
        StringBuilder sb = new StringBuilder();
        float retValue = 0;
        int ix = 0;
        for (int i = _MaxArray - 1; i > 0; i--)
        {
            if (m_arrNumber[i] > 0)
            {
                if(m_arrNumber[i] > 99)
                {
                    retValue = m_arrNumber[i];
                }else
                {
                    retValue = m_arrNumber[i] + (m_arrNumber[i - 1] * 0.0001f);
                }
                ix = i;
                break;
            }
        }
        if(ix == 0)
        {
            // 단자리만 있다.
            retValue = m_arrNumber[0];
        }
        sb.AppendFormat(_getTextUpperFormat, retValue, m_Unit[ix]);
        
        return sb.ToString();
    }
    public float GetUpperValue()
    {
        float retValue = 0;
        int ix = 0;
        for (int i = _MaxArray - 1; i > 0; i--)
        {
            if (m_arrNumber[i] > 0)
            {
                if (m_arrNumber[i] > 99)
                {
                    retValue = m_arrNumber[i];
                }
                else
                {
                    retValue = m_arrNumber[i] + (m_arrNumber[i - 1] * 0.0001f);
                }
                ix = i;
                break;
            }
        }
        if (ix == 0)
        {
            // 단자리만 있다.
            retValue = m_arrNumber[0];
        }
        return retValue;
    }
    public void SetValue(float val, string str_unit)
    {
        Clear();
        AddValue(val, str_unit);
    }
    public void AddValue(float val, int ix_unit)
    {
        m_arrNumber[ix_unit] += val;
        CarryCalc();
    }

    public void AddValue(float val, string str_unit)
    {
        int ix = 0;
        for(int i=0; i<m_Unit.Length; i++)
        {
            if(str_unit == m_Unit[i])
            {
                ix = i;
                break;
            }
        }
        AddValue(val, ix);
        
    }

    // 케리는 높은 곳에서 소수점 처리를 먼저 하고 낮은곳 부터 케리 처리 한다.
    void CarryCalc()
    {
        // 소수점 처리.
        for(int i= _MaxArray-1; i>0; i--)
        {
            float tmpValue = m_arrNumber[i] - Mathf.Floor(m_arrNumber[i]);
            if(tmpValue == 0 )
            {
                continue;
            }
            m_arrNumber[i - 1] += Mathf.Floor(tmpValue * 10000);
        }

        // carry
        for(int i=0; i<m_Unit.Length-1;i++)
        {
            if(m_arrNumber[i] > 9999)
            {
                float carry_val = Mathf.Floor(m_arrNumber[i] * 0.0001f);
                m_arrNumber[i + 1] += carry_val;
                m_arrNumber[i] = m_arrNumber[i] - (carry_val * 10000);
            }
            // - 인경우 상위 숫자 가져와 빼준다.
            if (m_arrNumber[i] < 0)
            {
                m_arrNumber[i + 1]--;
                m_arrNumber[i] = 10000 + m_arrNumber[i]; // - 값 이라서
            }

        }

        
    }

    public bool is_GTValue(float val, string str_unit)
    {
        int ix = 0;
        for (int i = 0; i < m_Unit.Length; i++)
        {
            if (str_unit == m_Unit[i])
            {
                ix = i;
                break;
            }
        }
        return is_GTValue(val, ix);
    }
    public bool is_GTValue(float val, int str_unit)
    {
        // 설정 단위 보다 높은 단위에 값이 있으면 false
        for(int i= m_Unit.Length-1; i>str_unit; i-- )
        {
            if(m_arrNumber[i] > 0 )
            {
                return false;
            }
        }
        if (m_arrNumber[str_unit] < val)
            return true;
        else
            return false;
    }

    public void SubValue(float val, string str_unit)
    {
        int ix = 0;
        for (int i = 0; i < m_Unit.Length; i++)
        {
            if (str_unit == m_Unit[i])
            {
                ix = i;
                break;
            }
        }
        SubValue(val, ix);

    }
    public void SubValue(float val, int ix_unit)
    {
        m_arrNumber[ix_unit] -= val;
        CarryCalc();
    }
}
