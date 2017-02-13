using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public GameObject[] hovers;

    public float fAccel = 100f;
    public float bAccel = 25f;
    float currentAccel;

    public float rotAmount = 10f;
    float currentRotAmount = 0f;

    public float hoverForce = 9f;
    public float hoverHeight = 2f;

    Rigidbody rb;

    public LayerMask groundLayer;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        currentAccel = 0f;
        if (vert > 0.12f)
        {
            currentAccel = vert * fAccel;
        }
        else if (vert < -0.12f)
        {
            currentAccel = vert * bAccel;
        }

        currentRotAmount = 0f;
        if (Mathf.Abs(hor) > 0.12f)
        {
            currentRotAmount = hor;
        }
		
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        for (int i = 0; i < hovers.Length; i++)
        {
            //var hover = hovers[i];
            //if it hits ground
            if (Physics.Raycast(hovers[i].transform.position, -Vector3.up, out hit, hoverHeight, groundLayer))
            {
                rb.AddForceAtPosition(Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hovers[i].transform.position);
            }
            else    //fall
            {
                if (transform.position.y > hovers[i].transform.position.y)
                {
                    rb.AddForceAtPosition(hovers[i].transform.up * hoverForce, hovers[i].transform.position);
                }
                else
                {
                    rb.AddForceAtPosition(hovers[i].transform.up * -hoverForce, hovers[i].transform.position);
                }
            }
        }
        rb.AddForce(transform.forward * currentAccel);

        rb.AddRelativeTorque(Vector3.up * currentRotAmount * rotAmount);


    }
}
