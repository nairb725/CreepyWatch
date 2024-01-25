using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    [SerializeField]
    public bool _isRight;

    private RectTransform rt;

    private void Start()
    {
        _isRight = true;
    }

    public void ArrowPointing()
    {
        rt = GetComponent<RectTransform>();
        if(rt.transform.localRotation.y == 0)
        {
            rt.Rotate(Vector3.up, 180);
            _isRight = false;
        }
        else
        {
            rt.Rotate(Vector3.up, -180);
            _isRight = true;
        }   
    }
}
