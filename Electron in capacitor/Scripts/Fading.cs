using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fading : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isFading = false;
    private float oldPosition;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldPosition = transform.position.y;
    }

    void Start()
    {

    }

    void Update()
    {

    }
    public void StartFading()
    {
        StartCoroutine(PowerLineFading());
    }

    IEnumerator PowerLineFading()
    {
        isFading = true;
        var powerLineColor = spriteRenderer.color;
        for (float ft = 0; ft <= 1.0f; ft += 0.01f)
        {
            powerLineColor.a = ft;
            spriteRenderer.color = powerLineColor;
            yield return new WaitForSeconds(0.02f);
        }
        for (float ft = 1.0f; ft >= 0.0f; ft -= 0.01f)
        {
            powerLineColor.a = ft;
            spriteRenderer.color = powerLineColor;
            yield return new WaitForSeconds(0.02f);
        }
        var color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        isFading = false;
    }
}
