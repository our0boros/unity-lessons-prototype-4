﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float minY = 0;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
