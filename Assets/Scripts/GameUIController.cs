using System;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI roundInfo;
    public TextMeshProUGUI elapsedTimeText;

    private float _timer;

    public void UpdateKills(int numberOfKills, int maxKills)
    {
        killsText.text = string.Format("{0}/{1}", numberOfKills, maxKills);
    }

    public void UpdateRoundInfo(string info)
    {
        roundInfo.text = info;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        DateTime dateTime = new DateTime();
        dateTime = dateTime.AddSeconds(_timer);

        elapsedTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", 
            dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
}