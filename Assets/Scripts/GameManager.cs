using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private float _startTime;

    [SerializeField]
    private TMP_Text m_TimerText;

    [SerializeField]
    private bool _isTimer = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isTimer == true)
        {
            float currentTime = Time.time - _startTime;
            int minute = Mathf.FloorToInt(currentTime / 60F);
            int second = Mathf.FloorToInt(currentTime - minute * 60);
            m_TimerText.text = string.Format("{0:0}:{1:00}", minute, second);
        }
    }
}
