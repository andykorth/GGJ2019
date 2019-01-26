using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    
    public Vector3 vel = Vector3.zero;
    public float speed = 3.0f;
    public float accel = 0.1f;
    public float gravity = 3f;

    public float jumpVel = 10;

    void Update()
    {
        float y = vel.y + Time.deltaTime * -gravity;
        
        Vector3 newVel = new Vector3(Input.GetAxis("Horizontal") * speed, y, Input.GetAxis("Vertical") * speed);

        vel = Vector3.Lerp(vel, newVel, accel);

        if(Input.GetKeyDown(KeyCode.Space)){
            // jump:
            vel.y = jumpVel;
        }

        rb.velocity = vel;

    }
}
