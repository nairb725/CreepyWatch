using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private GameObject loseCanvas, winCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loseCanvas.activeSelf || winCanvas.activeSelf) 
        {
            gameObject.SetActive(false);
        }
    }
}
