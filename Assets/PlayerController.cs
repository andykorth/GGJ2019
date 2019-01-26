using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float gravity = 1;
    
    void Update()
    {
        Vector3 t = new Vector3(Input.GetAxis("Horizontal"), 0,  Input.GetAxis("Vertical"));
        rb.AddTorque(t);


    }
}
