using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulsate : MonoBehaviour
{
    public Light lightSource;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1f;
    public float pulseSpeed = 1f;
    private float currentIntensity;

    private void Start()
    {
        currentIntensity = lightSource.intensity;
    }

    private void Update()
    {
        lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
    }
}
