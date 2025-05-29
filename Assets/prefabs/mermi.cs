using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 500f);
    }
    void Update()
    {
        
    }
}
