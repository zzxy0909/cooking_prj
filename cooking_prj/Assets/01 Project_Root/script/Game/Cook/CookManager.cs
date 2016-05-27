using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookManager : MonoBehaviour {

    #region Singleton

    private static CookManager _instance = null;

    public static CookManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion Singleton

    public List<CookBase> _cookEntityPools = new List<CookBase>();

    public E_RecipeEnum m_CurrentRecipe;


    protected void Awake()
    {
        _instance = this;
    }
    protected void OnDestroy()
    {
        StopAllCoroutines();

        _instance = null;
    }

    public T Find<T>() where T : CookBase
    {
        for (int i = 0; i < _cookEntityPools.Count; i++)
        {
            if (_cookEntityPools[i].gameObject.name == typeof(T).ToString())
            {
                return _cookEntityPools[i] as T;
            }
        }

        return null;
    }

}
