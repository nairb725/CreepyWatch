using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light lightOB;

    public AudioSource LightBlinking;

    public float mintime;
    public float maxtime;
    public float timer;

    void Start()
    {
        timer = Random.Range(mintime, maxtime);
    }

    private void Update()
    {
        Blinking();        
    }

    void Blinking()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            lightOB.enabled = !lightOB.enabled;
            timer = Random.Range(mintime, maxtime);
            LightBlinking.Play();
        }
    }


}
