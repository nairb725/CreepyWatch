using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Circle2 : MonoBehaviour
{
    private float t = 0.0f;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float reduceValue;

    private RectTransform rt;
    Image imageComponent;
    Gradient gradient;
    GradientColorKey[] colorKeys;
    GradientAlphaKey[] alphaKeys;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();
        SetGradient();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor(rt.sizeDelta.y);
        rt.sizeDelta = new Vector2(Mathf.Lerp(0.02f, 2.0f, t), Mathf.Lerp(0.02f, 2.0f, t));
        t += 0.5f * Time.deltaTime * speed;
        if (t >= 1.0f)
        {
            // Here, Set anomaly
        }
    }

    public void ReduceCircleSize()
    {
        t += -reduceValue;
        if (t < 0.02f) { t = 0.02f; }
    }

    void ChangeColor(float value)
    {
        imageComponent.color = gradient.Evaluate(value / 2.0f);
    }

    void SetGradient()
    {
        gradient = new Gradient();

        colorKeys = new GradientColorKey[3];
        colorKeys[0].color = Color.green;
        colorKeys[0].time = 0.0f;
        colorKeys[1].color = new Color(1, 0.64f, 0);
        colorKeys[1].time = 0.5f;
        colorKeys[2].color = Color.red;
        colorKeys[2].time = 1.0f;

        alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 1.0f;

        gradient.SetKeys(colorKeys, alphaKeys);
    }
}
