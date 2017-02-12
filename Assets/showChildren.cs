using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showChildren : MonoBehaviour {

    bool childrenOn = false;
	// Use this for initialization

    void Start()
    {
        Two();
    }
    public void Show()
    {
        childrenOn = !childrenOn;
        Two();
    }

    void Two()
    {
        if (childrenOn)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
}
