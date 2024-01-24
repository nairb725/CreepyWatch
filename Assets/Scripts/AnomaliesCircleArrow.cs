using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomaliesCircleArrow : MonoBehaviour
{
    public List<GameObject> korner;

    // make the anomaliesCircleArrow in a start function but every 20 seconds
    void Start()
    {
        InvokeRepeating("AnomaliesCircleArrowAppear", 20, 20);
    }

    //This function will chose randomly one of the four quadrants and will make it appear on the screen but only ona at a time
    void AnomaliesCircleArrowAppear()
    {
       for (int i = 0; i < korner.Count; i++)
        {
            korner[i].SetActive(false);
        }

       int random = Random.Range(0, korner.Count);
       korner[random].SetActive(true);
    }

    // if the collider of the arrow touche the collider of the quarter make the quarter disappear
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            gameObject.SetActive(false);
        }
    }





}
