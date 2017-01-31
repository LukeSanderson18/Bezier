using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public float distance = 2f;
    public float smoothing = 2f;
    bool isGrounded = false;

    void HitTest()
    {
        Vector3 position = transform.position + transform.TransformDirection(Vector3.up) * 0.2f;
        Vector3 dir = transform.TransformDirection(-Vector3.up);
        Ray ray = new Ray(position, dir);

        //

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, hit, distance))
        {
            if (hit.collider.tag == "Tube")
            {
                isGrounded = true;
                this.transform.position = hit.point;

                Debug.DrawLine(hit.point, hit.point + hit.normal, Color.blue);

                Vector3 curVec3 = position - hit.point;
                Vector3 targetVec3 = hit.normal;

                Debug.DrawLine(hit.point, hit.point + curVec3.normalized, Color.white);

                Quaternion targetQuat;

                Vector3 fPos = transform.position + transform.TransformDirection(new Vector3(0, 1f, 1f));
                Vector3 fDir = transform.TransformDirection(-Vector3.up);

                Ray fRay = new Ray(fPos, fDir);
                RaycastHit fHit;
                float fDistance = 2f;

                Debug.DrawLine(fRay.origin, fRay.origin + fRay.direction * fDistance, Color.magenta);

                if (Physics.Raycast(fRay, fHit, fDistance))
                {
                    if (fHit.collider.tag == "Tube")
                    {
                        Debug.DrawLine(fHit.point, fHit.point + fHit.normal * fDistance, Color.cyan);
                        targetQuat.SetLookRotation(fHit.point - transform.position, targetQuat);
                    }
                }

                if (targetQuat == null)
                {
                    targetQuat.SetLookRotation(transform.TransformDirection(Vector3.forward), targetQuat);
                }

                this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, targetQuat, smoothing);

            }

            return isGrounded;

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
