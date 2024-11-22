using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseKontrolleri : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePozisyonu = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 nesnePozisyonu = Camera.main.ScreenToWorldPoint(mousePozisyonu);
        transform.position = nesnePozisyonu;
        rb.isKinematic = true;

    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }
    
}
