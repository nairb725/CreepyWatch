using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
    [SerializeField] private GameObject m_TempText;

    Temperature temperature;
    float newTemp = 0;

    // Start is called before the first frame update
    void Start()
    {
        temperature = m_TempText.GetComponent<Temperature>();
        StartCoroutine(UpdateTemp());
    }

    // Update is called once per frame
    void Update()
    {
        if (LeverOrientation() != 0f) 
        {
            if (LeverOrientation() < -0.05f)
            {
                if (LeverOrientation() >= -0.10) { newTemp = -1; }
                if (LeverOrientation() < -0.10 && LeverOrientation() >= -0.20) { newTemp = -2; }
                if (LeverOrientation() < -0.20 && LeverOrientation() >= -0.30) { newTemp = -3; }
            }
            else if (LeverOrientation() > 0.05f) 
            {
                if (LeverOrientation() <= 0.10) { newTemp = 1; }
                if (LeverOrientation() > 0.10 && LeverOrientation() <= 0.20) { newTemp = 2; }
                if (LeverOrientation() > 0.20 && LeverOrientation() <= 0.30) { newTemp = 3; }
            }
        }
    }

    float LeverOrientation()
    {
        return transform.rotation.x;
    }

    IEnumerator UpdateTemp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            temperature.UpdateTemperature(newTemp);
        }
    }
}
