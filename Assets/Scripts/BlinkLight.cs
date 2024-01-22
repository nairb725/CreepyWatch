using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light light;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.0f;
    public float speed = 1.0f;
    public AudioSource lightSource;

    public float minTime = 0.5f;
    public float maxTime = 1.0f;
    public float time;

    private float intensity;

    void Start()
    {
        intensity = Random.Range(0.0f, 65535.0f);
        time = Random.Range(minTime, maxTime);

    }

    void Update()
    {
        LightFlickering();
    }

    void LightFlickering()
    {
        if (time > 0)
        {
            float noise = Mathf.PerlinNoise(intensity, Time.time * speed);
            light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        }

        if (time <= 0)
        {
            time = Random.Range(minTime, maxTime);
            intensity = Random.Range(0.0f, 65535.0f);
            lightSource.Play();
        }

    }



}
