using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreboardText;
    int score = 0;

    public void ModifyScore(int amount)
    {
        score += amount;
        ScoreboardText.text = score.ToString();
    }
}
