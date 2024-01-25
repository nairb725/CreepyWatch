using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickDirection : MonoBehaviour
{

    [SerializeField]
    public bool _isRight;

    [SerializeField]
    private GameManager _gameManager;

    public void Start()
    {
        _isRight = true;
    }

    public void Right()
    {
        if (!_isRight)
        {
            _isRight = true;
            _gameManager.DisplayArrow();
        }
    }

    public void Left()
    {
        if (_isRight)
        {
            _isRight = false;
            _gameManager.DisplayArrow();
        }
    }

}
