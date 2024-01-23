using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    [SerializeField]
    public float m_Temperature;

    [SerializeField]
    private GameManager gameManager;

    private TextMeshProUGUI tmp;
    private bool _TempAnomalyOccuring;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoChangeTemp());
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _TempAnomalyOccuring = gameManager.TempAnomalyOccuring;

        

        tmp.text = $"{m_Temperature} °C";
        if (m_Temperature > 40 && m_Temperature < 70) { tmp.color = Color.white; }
        if (m_Temperature >= 70) { tmp.color = Color.red; }
        if (m_Temperature <= 40) { tmp.color = Color.blue; }
    }

    public void UpdateTemperature(float addTemp)
    {
        if (addTemp != 0) 
        {
            m_Temperature += addTemp;
        }
        else if (!_TempAnomalyOccuring)
        { 
            m_Temperature = 55; 
        }
    }

    IEnumerator AutoChangeTemp()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            int number = Random.Range(1, 3);
            switch (number)
            {
                case 1:
                    UpdateTemperature(1);
                    break;
                case 2:
                    UpdateTemperature(0);
                    break;
                case 3:
                    UpdateTemperature(-1);
                    break;
            }
        } 
    }
}
