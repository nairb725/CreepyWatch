using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float _startTime;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private float TimerCountMax;

    private float TimeLeft;
    [SerializeField]
    private bool _isTimer = true;

    void Start()
    {
        _startTime = Time.time;
        TimeLeft = TimerCountMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTimer && TimeLeft > 0)
        {
            TimeLeft = Mathf.Clamp(TimerCountMax - (Time.time - _startTime), 0f, TimerCountMax);

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(TimeLeft / 60F);
        int seconds = Mathf.FloorToInt(TimeLeft - minutes * 60);

        m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
