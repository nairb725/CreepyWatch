using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVD : MonoBehaviour
{
    private Rigidbody2D rb;
    private RectTransform rt;
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = rb.GetComponent<RectTransform>();
        rb.velocity = RandomVector(0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rt.position.x >= 1.75f)
        {
            rb.velocity = RandomVector(0f, 5f);
        }
    }
}
