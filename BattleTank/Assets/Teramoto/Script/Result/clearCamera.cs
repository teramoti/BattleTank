﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearCamera : MonoBehaviour
{
    public Transform myTransform;

    private float s_phi_ang = 0.0f;
    private const float s_dist = 10.0f;
    private const float kYPos = 6.0f;

    [Range(-2.0f, 2.0f)]
    public float rotationSpeed = 0.5f; // degree

    float ToRadian(float deg)
    {
        return deg * Mathf.PI / 180.0f;
    }

    void SetPosition()
    {
        float xpos = s_dist * Mathf.Sin(ToRadian(s_phi_ang));
        float zpos = s_dist * Mathf.Cos(ToRadian(s_phi_ang));
        Vector3 vec = new Vector3(xpos, kYPos, zpos);
        transform.position = vec;

        transform.LookAt(myTransform);
    }

    void AddPhiAngle()
    {
        s_phi_ang += rotationSpeed;
    }

    void Start()
    {
        SetPosition();
    }

    void Update()
    {
        AddPhiAngle();
        SetPosition();
    }
}