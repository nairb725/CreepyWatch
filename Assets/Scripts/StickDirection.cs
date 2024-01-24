using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickDirection : MonoBehaviour
{

    [SerializeField]
    public bool _isRight;

    public void Right()
    {
        _isRight = true;
    }

    public void Left()
    {
        _isRight = false;
    }

}
