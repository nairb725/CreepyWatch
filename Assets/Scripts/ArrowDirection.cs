using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    [SerializeField]
    public bool _isRight;

    private RectTransform rt;

    [SerializeField]
    private int[] integers;

    public void ArrowPointing()
    {
        integers[0] = 180;
        integers[1] = 0;
        rt = GetComponent<RectTransform>();
        var direction = integers[Random.Range(0, 2)];
        rt.Rotate(Vector3.up, direction);
        if(rt.transform.localRotation.y == 0)
        {
            _isRight = true;
        }
        else
        {
            _isRight = false;
        }   
    }
}
