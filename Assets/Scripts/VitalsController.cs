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

    [SerializeField]
    private AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.space = ParticleSystemSimulationSpace.Local;
    }

    // Update is called once per frame
    void Update()
    {
        vel.y = new ParticleSystem.MinMaxCurve(10f*(gameManager.AnomalyTime%60), curve);
    }
}
