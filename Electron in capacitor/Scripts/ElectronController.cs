using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class ElectronController : MonoBehaviour
{
    public float speed = 0f;
    private const float electronCharge = -1.602f * (float)1e-19;
    private const float electronMass = 9.109f * (float)1e-31;
    private Stopwatch stopwatch = new Stopwatch();

    void Start()
    {
        speed = 0f;
    }

    public void AddConstantSpeed(float speed)
    {
        this.speed += speed;
    }

    void OnBecameInvisible()
    {
        speed = 0f;
        stopwatch.Reset();
        transform.position = new Vector3(-9f, 2f, 0f);
    }

    void Update()
    {
        var lines = FindObjectOfType<PowerLinesAnimationController>();
        if (transform.position.x >= 0f)
        {
            stopwatch.Start();
        }
        else if (transform.position.x > 13f)
        {
            stopwatch.Stop();
        }
        var capacitorController = FindObjectOfType<CapacitorController>();
        var horizontalSpeed = speed * Time.deltaTime / (float)1e14;
        transform.position = new Vector3(transform.position.x + horizontalSpeed, transform.position.y);
        if (lines.enabled)
        {
            var tension = capacitorController.voltage / capacitorController.distanceBetweenPlates;
            var acceleration = electronCharge * tension / electronMass;
            float verticalSpeed = 0f;
            if (speed >= Mathf.Epsilon)
                verticalSpeed = acceleration * ((float)stopwatch.ElapsedMilliseconds / 1000) / speed;
            transform.position = new Vector3(transform.position.x, transform.position.y - verticalSpeed * Time.deltaTime);
        }
    }
}
