using UnityEngine;
using System.Collections;

public class CheckSlotPosition : MonoBehaviour {
    public Vector3 _LastPosition;
    public string m_TargetTag = "slot";
    public bool m_isTriggerPlay = false;
	// Use this for initialization
	void Start () {
        SetLastPosition();
	}

    public void SetDragEnd()
    {
        // 트리거로 처리되지않았다면.
        if(m_isTriggerPlay == true)
        {

        }
        Invoke("SetLastPosition", 0.3f);
    }

    public void SetLastPosition()
    {
        _LastPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("~~~~~~~~~~~~~~~~~ OnTriggerEnter " + col.gameObject.name);

        if (col.tag == m_TargetTag)
        {
            this.transform.position = _LastPosition;
        }
    }

    public void CheckTriggerPos()
    {

    }
}
