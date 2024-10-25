using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{

    private Camera _mainCamera;

    private Rigidbody _rigidbodyToJump = null;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast on screen touch
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Object name: " + hit.transform.name);
                if (hit.rigidbody != null)
                {
                    _rigidbodyToJump = hit.rigidbody;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbodyToJump != null)
        {
            Debug.Log("Force before :" + _rigidbodyToJump.velocity);
            _rigidbodyToJump.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            StartCoroutine(RigidbodyVelocity(_rigidbodyToJump));

            _rigidbodyToJump = null;
        }

    }

    private IEnumerator RigidbodyVelocity(Rigidbody rb)
    {
        yield return new WaitForFixedUpdate();

        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Force after :" + rb.velocity);
            yield return new WaitForSeconds(0.1f);
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDrawGizmos()
    {
        //draw ray 
        if (_mainCamera == null)
            return;
        Ray ray = _mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
        Gizmos.DrawRay(ray);
    }
}
