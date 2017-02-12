using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public bool selected;
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        selected = true;
        transform.GetChild(1).gameObject.SetActive(true);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint),offset;
        transform.position = curPosition;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selected = false;
        }

        if (!selected)
        {

            transform.GetChild(1).gameObject.SetActive(false);
        }

        

        
    }
}
