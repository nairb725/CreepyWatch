using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    [SerializeField]
    private bool _isRight = false;

    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_isRight == true)
        {

        }
        else
        {
            rt.Rotate(new Vector3(0, 0, 180));
        }
    }
}
