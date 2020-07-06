using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CapacitorController : MonoBehaviour
{
    public float voltage;
    public float distanceBetweenPlates;
    public float platesLength;
    public Transform TopPlate;
    public Transform BottomPlate;
    public Transform PowerLines;

    void Start()
    {
        distanceBetweenPlates = (TopPlate.position.y - BottomPlate.position.y) / 1000;
        platesLength = TopPlate.localScale.x / 1000;
    }

    public void OnValueChanged(string value)
    {
        var oldVoltage = voltage;-
        try
        {
            voltage = float.Parse(value);
        }
        catch (Exception)
        {
            return;
        }
        if (oldVoltage >= 0f)
        {
            if (voltage >= 0f)
            {
                PowerLines.transform.localScale = new Vector3(Math.Abs(PowerLines.transform.localScale.x), Math.Abs(PowerLines.transform.localScale.y));
            }
            else
            {
                PowerLines.transform.localScale = new Vector3(Math.Abs(PowerLines.transform.localScale.x), -Math.Abs(PowerLines.transform.localScale.y));
            }
        }
        else
        {
            if (voltage >= 0f)
            {
                PowerLines.transform.localScale = new Vector3(Math.Abs(PowerLines.transform.localScale.x), Math.Abs(PowerLines.transform.localScale.y));
            }
            else
            {
                PowerLines.transform.localScale = new Vector3(Math.Abs(PowerLines.transform.localScale.x), -Math.Abs(PowerLines.transform.localScale.y));
            }
        }
    }

    void Update()
    {

    }
}
