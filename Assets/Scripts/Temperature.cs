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
    }

    public void UpdateTemperature (float addTemp)
    {
        m_Temperature += addTemp;
    }

    IEnumerator AutoChangeTemp ()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            float number = Random.Range(0f, 100f);
            Debug.Log(number);
            if (number <= 1)
            {
                Debug.Log("UP " + number);
                UpdateTemperature(1);
            }
            else if (number > 1 && number <= 2)
            {
                Debug.Log("DOWN " + number);
                UpdateTemperature(-1);
            }
        }
    }
}
