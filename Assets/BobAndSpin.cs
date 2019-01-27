using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAndSpin : MonoBehaviour
{

    public float height = 0.5f;
    public float speed = 2.0f;
    private Vector3 startpos;

    void Start(){
        startpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float y = (Mathf.Sin(Time.time * speed) + 1) * height;
        transform.localPosition = startpos + new Vector3(0, y, 0);
        transform.localRotation = Quaternion.Euler(0, (Time.time * 10f) % 360.0f, 0);
    }
}
