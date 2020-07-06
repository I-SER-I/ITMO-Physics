using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerLinesAnimationController : MonoBehaviour
{
    public Transform powerLinesParent;
    private List<Transform> _powerLines;
    private float[] _powerLinesStartVerticalPosition;

    void Start()
    {
        _powerLines = powerLinesParent.GetComponentsInChildren<Transform>().ToList();
        _powerLines.RemoveAt(0);
        foreach (var powerLine in _powerLines)
        {
            var renderer = powerLine.GetComponent<SpriteRenderer>();
            var color = renderer.color;
            color.a = 0f;
            renderer.color = color;
            powerLine.gameObject.AddComponent<Fading>();
        }
        this.enabled = false;
    }

    public void OnTurnOffField()
    {
        this.enabled = false;
    }

    public void OnTurnOnField()
    {
        this.enabled = true;
    }

    void Update()
    {
        foreach (var powerLine in _powerLines)
        {
            var fadingPowerLine = powerLine.GetComponent<Fading>();
            if(!fadingPowerLine.isFading)
                fadingPowerLine.StartFading();
        }
    }
}
