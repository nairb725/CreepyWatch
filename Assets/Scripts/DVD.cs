using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DVD : MonoBehaviour
{
    private Rigidbody2D rb;
    private RectTransform rt;
    private TextMeshProUGUI tmp;
    private Vector2 RandomVector(float minX, float maxX, float minY, float maxY)
    {
        var x = Random.Range(minX, maxX);
        var y = Random.Range(minY, maxY);
        return new Vector2(x, y);
    }

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody2D>();
        rt = rb.GetComponent<RectTransform>();
        rb.velocity = RandomVector(0f, 1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rt.anchoredPosition.x >= 1.75f)
        {
            rb.velocity = RandomVector(-1f, 0f, -1f, 1f);
        }
        if (rt.anchoredPosition.x <= -1.75f)
        {
            rb.velocity = RandomVector(0f, 1f, -1f, 1f);
        }
        if (rt.anchoredPosition.y >= 0.75f)
        {
            rb.velocity = RandomVector(-1f, 1f, -1f, 0f);
        }
        if (rt.anchoredPosition.y <= -0.75f)
        {
            rb.velocity = RandomVector(-1f, 1f, 0f, 1f);
        }
    }
}
