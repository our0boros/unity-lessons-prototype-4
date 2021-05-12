using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float axisRotationSpeed = 0;
    public float mouseRotationSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * axisRotationSpeed;
        float mInput = Input.GetAxis("Mouse X") * mouseRotationSpeed;

        float input = hInput != 0 ? hInput : mInput;

        transform.Rotate(Vector3.up * input * Time.deltaTime);
    }
}
