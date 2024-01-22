using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    [SerializeField]
    private bool _isRight = false;

    private RectTransform rt;

    [SerializeField]
    private int[] integers;

    void Start()
    {

        integers[0] = 180;
        integers[1] = 0;
        rt = GetComponent<RectTransform>();
    }

    public void ArrowPointing()
    {
        var direction = integers[Random.Range(0, 2)];
        rt.Rotate(Vector3.up, direction);
    }
}
