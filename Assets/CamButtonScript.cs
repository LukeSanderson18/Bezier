using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamButtonScript : MonoBehaviour {

    public void ZoomIn()
    {
        Camera.main.transform.Translate(Vector3.forward * 1);
    }
    public void ZoomOut()
    {
        Camera.main.transform.Translate(Vector3.forward * -1);
    }
}
