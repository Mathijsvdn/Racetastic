using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCarController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float _force = Input.GetAxis("Vertical") * speed;
        float _rot = Input.GetAxis("Horizontal") * rotationSpeed;
        if(_force != 0f)
        {
            rb.AddForce(transform.forward * _force * Time.fixedDeltaTime);
        }
        rb.rotation = rb.rotation * Quaternion.Euler(0f, _rot * Time.fixedDeltaTime, 0f);
    }
}
