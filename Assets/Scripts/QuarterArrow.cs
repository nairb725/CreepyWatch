using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarterArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject rotator;
    

    void Update()
    {
        //get the Y rotation of the rotator and use it to change the rotation of the Z axis of the arrow
        arrow.transform.rotation = Quaternion.Euler(0, rotator.transform.rotation.eulerAngles.y, 0);
    }
}
