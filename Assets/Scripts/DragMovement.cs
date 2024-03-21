using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : MonoBehaviour
{
    float hoverHeight = 0.7f;
    public bool isDragging = true;
    Ray ray;
	RaycastHit hit;
    Rigidbody rb;
    float xLimit = 4.5f;
    float zLimit = 4.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        } 
    }
	
	void Update()
	{
        if (isDragging)
        {
            Drag();
        }
		
	}

    void OnMouseUp()
    {
        if (transform.position.x < xLimit && transform.position.x > -xLimit && transform.position.z < zLimit && transform.position.z > -zLimit)
        {
            isDragging = false;
            if (rb != null)
            {
                rb.useGravity = true;
            }
        }
        
    }

    void Drag()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
            transform.position = new Vector3(hit.point.x, hoverHeight, hit.point.z);
		}
    }

    public bool isPlaced()
    {
        return !isDragging;
    }
}
