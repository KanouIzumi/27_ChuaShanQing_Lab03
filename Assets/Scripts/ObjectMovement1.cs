﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement1 : MonoBehaviour
{
    private float ySpeed = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, ySpeed * Time.deltaTime, 0f));
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
