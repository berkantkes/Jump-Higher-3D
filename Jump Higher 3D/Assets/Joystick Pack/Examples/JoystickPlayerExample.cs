using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public DynamicJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] float ySpeed = -1;
    [SerializeField] float zSpeed = 10;

    public void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            ySpeed = -4;
            zSpeed = 15;
        }
        else
        {
            ySpeed = -12;
        }
        Vector3 direction = Vector3.up * ySpeed + Vector3.forward * zSpeed + Vector3.right * variableJoystick.Horizontal * 20;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}