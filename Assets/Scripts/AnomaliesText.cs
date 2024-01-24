using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnomaliesText : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = $"Current Anomalies :\n{gameManager.AnomalyOccuring}";
    }
}
