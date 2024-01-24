using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.Windows.Speech;
using Valve.VR.InteractionSystem.Sample;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _startTime, TimeLeft;
    private bool CausedByEvent;
    private int AnomalyOccuring = 0;
    public bool TempAnomalyOccuring = false;
    public float AnomalyTime = 5.0f;

    [SerializeField]
    private Canvas WinCanvas, GameoverCanvas;

    [SerializeField]
    private TextMeshProUGUI Grade;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private float TimerCountMax;

    [SerializeField]
    private bool _isTimer = true;

    [SerializeField]
    private GameObject GreenScreen, RedScreen, BlueScreen, YellowScreen;

    [SerializeField]
    public Temperature _temperature;

    [SerializeField]
    public ArrowDirection _arrowDirection;

    [SerializeField]
    public StickDirection stickDirection;

    [SerializeField]
    public TMP_Text TextInfoDead;

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

            CheckTemp(_temperature.m_Temperature);

            if (AnomalyOccuring < 0)
            {
                AnomalyOccuring = 0;
            }

            if (AnomalyOccuring > 0)
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
            else if (TimeLeft > 3 * 60 && TimeLeft < 4 * 60)
            {
                Grade.text = "D";
            }
            else if (TimeLeft > 4 * 60 && TimeLeft < 5 * 60)
            {
                Grade.text = "F";
            }
            GameoverCanvas.gameObject.SetActive(true);
        }
        StartCoroutine(SwitchScene(3f));
    }

    IEnumerator SwitchScene(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("main");
    }

    void RandomEvent()
    {
        float delay = Random.Range(10, 15);
        int EventID = Random.Range(1, 7);
        CausedByEvent = true;
        switch (EventID)
        {
            case 1:
                Debug.Log("called event 1 : green screen Off");
                ToggleScreen(GreenScreen);
                TextInfoDead.text = "Vous n'avez pas pressez le bouton vert à temps";
                break;

            case 2:
                Debug.Log("called event 1 : red screen Off");
                ToggleScreen(RedScreen);
                TextInfoDead.text = "Vous n'avez pas pressez le bouton rouge à temps";
                break;

            case 3:
                Debug.Log("called event 1 : blue screen Off");
                ToggleScreen(BlueScreen);
                TextInfoDead.text = "Vous n'avez pas pressez le bouton bleu à temps";
                break;
            case 4:
                Debug.Log("called event 1 : yellow screen Off");
                ToggleScreen(YellowScreen);
                TextInfoDead.text = "Vous n'avez pas pressez le bouton jaune à temps";
                break;
            case 5:
                Debug.Log("called event 5 : cold");
                ToggleTempAnomaly(Random.Range(-33, -7));
                TextInfoDead.text = "Vous n'avez pas pressez le bouton pour réinitialiser la température";
                break;
            case 6:
                Debug.Log("called event 6 : heat");
                ToggleTempAnomaly(Random.Range(90, 120));
                TextInfoDead.text = "Vous n'avez pas pressez le bouton pour réinitialiser la température";
                break;
            case 8:
        Debug.Log("called event 8 : arrow");
                TextInfoDead.text = "Vous n'avez pas mis le levier dans la position opposée à la flèche";
                break;
            case 9:
                Debug.Log("called event 9 : rien");
                break;
        }
        CausedByEvent = false;
        if(_isTimer && TimeLeft > 0)
        {
            Invoke("RandomEvent", delay);
        }
    }

    public void ToggleScreen(GameObject screen)
    {
        if (screen.activeSelf)
        {
            screen.gameObject.SetActive(false);
            AnomalyOccuring += 1;
        }
        else if (!CausedByEvent)
        {
            screen.gameObject.SetActive(true);
            AnomalyOccuring -= 1;
        }
    }

    public void ToggleTempAnomaly(float temp)
    {
        if (!TempAnomalyOccuring && CausedByEvent)
        {
            _temperature.m_Temperature = temp;
            AnomalyOccuring += 1;
        }
        else if (TempAnomalyOccuring)
        {
            _temperature.m_Temperature = temp;
            AnomalyOccuring -= 1;
        }
    }

    private void CheckTemp(float temp)
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
