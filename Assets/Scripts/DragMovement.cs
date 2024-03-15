using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : MonoBehaviour
{
    float hoverHeight = 0.7f;
    bool isDragging = true;
    Ray ray;
	RaycastHit hit;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
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
        isDragging = false;
        rb.useGravity = true;
    }


    void Drag()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
            transform.position = new Vector3(hit.point.x, hoverHeight, hit.point.z);
		}
    }
}
