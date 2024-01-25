using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomaliesCircleArrow : MonoBehaviour
{
    public List<GameObject> korner;

    public GameManager GameManager;

    public int One = 1;

    // make the anomaliesCircleArrow in a start function but every 20 seconds
    void Start()
    {
        InvokeRepeating("AnomaliesCircleArrowAppear", 20, 20);
    }

    //This function will chose randomly one of the four quadrants and will make it appear on the screen but only ona at a time
    public void AnomaliesCircleArrowAppear()
    {
       for (int i = 0; i < korner.Count; i++)
        {
            korner[i].SetActive(false);
        }

       int random = Random.Range(0, korner.Count);
       korner[random].SetActive(true);
       GameManager.AnomalyOccuring += 1;
    }
    
    //This function will make the anomaliesCircleArrow disappear when the Arrow enter the collider of the anomaliesCircleArrow
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Quarter");
        if (collision.gameObject.tag == "Quarter")
        {
            Debug.Log("Quarter");
            collision.gameObject.SetActive(false);
            GameManager.AnomalyOccuring -= 1;
            //Make the anomaliesCircleArrow appear again after 30 seconds
            Invoke("AnomaliesCircleArrowAppear", 30);
        }
    }



}
