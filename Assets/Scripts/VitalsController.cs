using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class VitalsController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private ParticleSystem ps;
    private ParticleSystem.VelocityOverLifetimeModule vel;
    //private ParticleSystem.MainModule main;
    private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        //main = ps.main;
        vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.space = ParticleSystemSimulationSpace.Local;
        
        curve = new AnimationCurve();
        curve.AddKey(0.0f, -0.3f);
        curve.AddKey(0.05f, 0.3f);
        curve.AddKey(0.1f, -0.3f);
        AnimationUtility.SetKeyRightTangentMode(curve, 0, AnimationUtility.TangentMode.ClampedAuto);
        AnimationUtility.SetKeyLeftTangentMode(curve, 2, AnimationUtility.TangentMode.ClampedAuto);
        curve.preWrapMode = WrapMode.Loop;
        curve.postWrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float i = 51f * (gameManager.AnomalyTime % 60);
        float r = 255 - i;
        float g = i;
        main.startColor = new Color(r, g, 0, 1f);
        */
        vel.y = new ParticleSystem.MinMaxCurve(10f*(gameManager.AnomalyTime%60), curve);
    }
}
