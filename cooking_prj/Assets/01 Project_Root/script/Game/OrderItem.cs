using UnityEngine;
using System.Collections;

public class OrderItem : MonoBehaviour {
    public E_RecipeEnum m_eRecipe;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OrderItemClick()
    {
        CookManager.Instance.ChangeCurrentRecipe(m_eRecipe);
        
    }
}
