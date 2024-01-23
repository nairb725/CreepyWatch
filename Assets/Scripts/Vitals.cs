using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitals : MonoBehaviour
{
    ParticleSystem vitalParticleSystem;

    float newYVelocity = 20.0f;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    AnimationCurve intensityCurve;

    // Start is called before the first frame update
    void Start()
    {
        vitalParticleSystem = GetComponent<ParticleSystem>();
        SetGradient();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetGradient()
    {
        gradient = new Gradient();

        colorKey = new GradientColorKey[5];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f; // 0

        colorKey[1].color = Color.red;
        colorKey[1].time = 1.0f; // 40

        colorKey[2].color = new Color(1, 0.64f, 0);
        colorKey[2].time = 0.25f; // 10

        colorKey[3].color = new Color(1, 0.64f, 0);
        colorKey[3].time = 0.75f; // 30

        colorKey[4].color = Color.green;
        colorKey[4].time = 0.5f; // 20

        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;

        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
    }

    void ChangeColor()
    {
        var main = vitalParticleSystem.main;
        Color colorAtValue = gradient.Evaluate(newYVelocity / 40.0f);
        main.startColor = colorAtValue;
    }

    public void UpdateValue(float yVelocity)
    {
        newYVelocity = Mathf.Clamp(newYVelocity + yVelocity, 0, 40);
        UpdateVelocity();
        ChangeColor();
        Debug.Log(newYVelocity);
    }

    void UpdateVelocity()
    {
        Debug.Log("Updating Velocity - newYVelocity: " + newYVelocity);

        var velocityModule = vitalParticleSystem.velocityOverLifetime;
        velocityModule.enabled = true;

        ParticleSystem.MinMaxCurve velocityCurveY = velocityModule.y;

        if (velocityCurveY.mode == ParticleSystemCurveMode.Constant)
        {
            velocityCurveY.constant = newYVelocity;
        }
        else if (velocityCurveY.mode == ParticleSystemCurveMode.Curve)
        {
            AnimationCurve curve = velocityCurveY.curve;
            for (int i = 0; i < curve.keys.Length; i++)
            {
                Keyframe key = curve.keys[i];
                float scaledValue = key.value * newYVelocity / 20.0f;
                key.value = Mathf.Clamp(scaledValue, 0, 40);
                curve.MoveKey(i, key);
            }
            velocityCurveY.curve = curve; // Reassign the modified curve
        }

        velocityModule.y = velocityCurveY;

        // Restart the Particle System to apply changes
        vitalParticleSystem.Stop();
        vitalParticleSystem.Play();
    }
}
