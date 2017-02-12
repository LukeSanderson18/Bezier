using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public bool selected;
    public string type = "";
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        print("ding!");
        selected = true;
        if (transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        if (type == "X")
        {
            transform.parent.parent.position = new Vector3(curPosition.x, transform.parent.parent.position.y, transform.parent.parent.position.z);
        }
        if (type == "Y")
        {
            transform.parent.parent.position = new Vector3(transform.parent.parent.position.x, curPosition.y, transform.parent.parent.position.z) ;
        }
        if (type == "Z")
        {
            transform.parent.parent.position = new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y, curPosition.z) ;
        }
        else
        {
            //transform.position = curPosition;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selected = false;
        }

        if (!selected)
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        

        
    }
}
