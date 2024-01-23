using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    [SerializeField]
    private float m_Temperature;

    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        StartCoroutine(AutoChangeTemp());
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = $"{m_Temperature} °C";
        if (m_Temperature > 40 && m_Temperature < 70) { tmp.color = Color.white; }
        if (m_Temperature >= 70) { tmp.color = Color.red; }
        if (m_Temperature <= 40) { tmp.color = Color.blue; }
    }

    public void UpdateTemperature(float addTemp)
    {
        m_Temperature += addTemp;
    }

    IEnumerator AutoChangeTemp()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            float number = Random.Range(0f, 6f);
            if (number <= 2)
            {
                UpdateTemperature(1);
            }
            else if (number > 2 && number <= 3)
            {
                UpdateTemperature(-1);
            }
            else if (number > 3 && number <= 4)
            {
                UpdateTemperature(2);
            }
            else if (number > 4 && number <= 5)
            {
                UpdateTemperature(-2);
            }
        }
    }

    public float temperature
    {
        get { return m_Temperature; }
    }
}
