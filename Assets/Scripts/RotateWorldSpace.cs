using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorldSpace : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3();

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
    }
}
