using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    
    public Vector3 vel = Vector3.zero;
    public float speed = 3.0f;
    public float airSpeed = 0.5f;

    public float dampen = 0.95f;

    public float jumpVel = 10;
    private Transform cameraTransform;

    public void Start(){
        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        bool grounded = Physics.Raycast(transform.position, -Vector3.up, 1.1f );

        float s = grounded ? speed : airSpeed;

        Vector3 addForce = cameraTransform.rotation * new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);

        if(Input.GetKeyDown(KeyCode.Space) && grounded ) {
            // jump:
            addForce.y += jumpVel;
        }

        rb.AddForce(addForce, ForceMode.Force);

        // dampen velocity
        rb.velocity = rb.velocity * dampen;

    }
}
