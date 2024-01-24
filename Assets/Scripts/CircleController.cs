using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] private GameObject m_Circle;

    Circle circle;

    // Start is called before the first frame update
    void Start()
    {
        circle = m_Circle.GetComponent<Circle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceCircle()
    {
        circle.ReduceCircleSize();
    }
}
