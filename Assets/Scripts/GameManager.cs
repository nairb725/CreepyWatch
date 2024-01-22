using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    private float _startTime;

    [SerializeField]
    private Canvas gameover;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private float TimerCountMax;

    private float TimeLeft;
    [SerializeField]
    private bool _isTimer = true;

    [SerializeField]
    private GameObject GreenScreen, RedScreen, BlueScreen, YellowScreen;

    void Start()
    {
        _startTime = Time.time;
        TimeLeft = TimerCountMax;
        Invoke("RandomEvent", Random.Range(5, 10));
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTimer && TimeLeft > 0)
        {
            TimeLeft = Mathf.Clamp(TimerCountMax - (Time.time - _startTime), 0f, TimerCountMax);

            UpdateTimerText();
        }
        if (TimeLeft <= 0) 
        { 
            _isTimer = false;
            GameOver();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(TimeLeft / 60F);
        int seconds = Mathf.FloorToInt(TimeLeft - minutes * 60);

        m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        gameover.gameObject.SetActive(true);
    }

    void RandomEvent()
    {
        float delay = Random.Range(10, 20);
        int EventID = Random.Range(1, 8);

        switch (EventID)
        {
            case 1:
                Debug.Log("called event 1");
                ToggleScreen(GreenScreen);
                break;
            case 2:
                Debug.Log("called event 2");
                ToggleScreen(RedScreen);
                break;
            case 3:
                Debug.Log("called event 3");
                ToggleScreen(BlueScreen);
                break;
            case 4:
                Debug.Log("called event 4");
                ToggleScreen(YellowScreen);
                break;
            case 5:
                Debug.Log("called event 5");
                ToggleScreen(GreenScreen);
                break;
            case 6:
                Debug.Log("called event 6");
                ToggleScreen(RedScreen);
                break;
            case 7:
                Debug.Log("called event 7");
                ToggleScreen(BlueScreen);
                break;
            case 8:
                Debug.Log("called event 8");
                ToggleScreen(YellowScreen);
                break;
        }

        Invoke("RandomEvent", delay);
    }

    void ToggleScreen(GameObject screen)
    {
        screen.gameObject.SetActive(false);
    }
}
