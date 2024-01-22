using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVD : MonoBehaviour
{
    private Rigidbody2D rb;
    private RectTransform rt;
    private Vector2 RandomVector(float minX, float maxX, float minY, float maxY)
    {
        var x = Random.Range(minX, maxX);
        var y = Random.Range(minY, maxY);
        return new Vector2(x, y);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = rb.GetComponent<RectTransform>();
        rb.AddForce(RandomVector(0f, 1f, 0f, 1f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(rt.anchoredPosition.x >= 1.75f)
        {
            rb.AddForce(RandomVector(-1f, 0f, -1f, 1f), ForceMode2D.Impulse);
        }
        if (rt.anchoredPosition.x <= -1.75f)
        {
            rb.AddForce(RandomVector(0f, 1f, -1f, 1f), ForceMode2D.Impulse);
        }
        if (rt.anchoredPosition.y >= 0.75f)
        {
            rb.AddForce(RandomVector(-1f, 1f, -1f, 0f), ForceMode2D.Impulse);
        }
        if (rt.anchoredPosition.y <= -0.75f)
        {
            rb.AddForce(RandomVector(-1f, 1f, 0f, 1f), ForceMode2D.Impulse);
        }
    }
}
