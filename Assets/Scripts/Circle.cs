using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float t = 0.0f;

    [SerializeField]
    private float speed;

    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
       rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rt.sizeDelta = new Vector2(Mathf.Lerp(0.1f,1.0f,t),Mathf.Lerp(0.1f, 1.0f, t));
        t += 0.5f * Time.deltaTime * speed;
        if (t > 1.0f)
        {
            t = 0.0f;
        }
    }
}
