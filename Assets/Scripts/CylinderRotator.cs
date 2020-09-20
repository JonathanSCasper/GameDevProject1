using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotator : MonoBehaviour
{
    public float speed = 7;
    public float direction = 1;
    public float AngularSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AngularSpeed = rb.angularVelocity.magnitude;
        //transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime);
        rb.AddTorque(Vector3.up * direction * 100f);
    }
}
