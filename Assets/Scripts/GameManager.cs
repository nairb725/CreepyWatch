using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Windows.Speech;

public class GameManager : MonoBehaviour
{
    private float _startTime;
    private bool CausedByEvent;
    private bool AnomalyOccuring = false;
    private bool TempAnomalyOccuring = false;
    private float AnomalyTime = 5.0f;

    [SerializeField]
    private Canvas GameoverCanvas;

    [SerializeField]
    private Canvas WinCanvas;

    [SerializeField]
    private TextMeshProUGUI Grade;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private float TimerCountMax;

    private float TimeLeft;
    [SerializeField]
    private bool _isTimer = true;

    [SerializeField]
    private GameObject GreenScreen, RedScreen, BlueScreen, YellowScreen;

    private Temperature _temperature;

    void Start()
    {
        _startTime = Time.time;
        _temperature = GameObject.FindObjectOfType<Temperature>();
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

            if (AnomalyOccuring || TempAnomalyOccuring)
            {
                AnomalyTimer();
            }
            else
            {
                AnomalyTime = 5.0f;
            }
        }
        if (TimeLeft <= 0)
        {
            _isTimer = false;
            GameOver();
        }
        CheckTemp(_temperature.temperature);
    }

    void AnomalyTimer()
    {
        AnomalyTime -= Time.deltaTime;
        float seconds = AnomalyTime % 60;
        if (seconds <= 0)
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
        if (TimeLeft <= 0)
        {
            WinCanvas.gameObject.SetActive(true);
        }
        else if (TimeLeft > 0)
        {
            if (TimeLeft > 0 && TimeLeft < 1 * 60)
            {
                Grade.text = "A";
            }
            else if (TimeLeft > 1 * 60 && TimeLeft < 2 * 60)
            {
                Grade.text = "B";
            }
            else if (TimeLeft > 2 * 60 && TimeLeft < 3 * 60)
            {
                Grade.text = "C";
            }
            else if (TimeLeft > 3 * 60 && TimeLeft < 5 * 60)
            {
                Grade.text = "D";
            }
            GameoverCanvas.gameObject.SetActive(true);
        }
    }

    void RandomEvent()
    {
        float delay = Random.Range(10, 20);
        int EventID = Random.Range(1, 8);
        CausedByEvent = true;

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
        CausedByEvent = false;
        Invoke("RandomEvent", delay);
    }

    public void ToggleScreen(GameObject screen)
    {
        if (screen.activeSelf)
        {
            screen.gameObject.SetActive(false);
            AnomalyOccuring = true;
        }
        else if (!CausedByEvent)
        {
            screen.gameObject.SetActive(true);
            AnomalyOccuring = false;
        }
    }

    public void CheckTemp(float temp)
    {
        if (temp <= 40f || temp >= 70f)
        {
            TempAnomalyOccuring = true;
        }
        else if (temp > 40f || temp < 70f)
        {
            TempAnomalyOccuring = false;
        }
    }
}
