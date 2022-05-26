using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI roundInfo;

    public void UpdateKills(int numberOfKills, int maxKills)
    {
        killsText.text = string.Format("{0}/{1}", numberOfKills, maxKills);
    }

    public void UpdateRoundInfo(string info)
    {
        roundInfo.text = info;
    }
}