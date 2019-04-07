using UnityEngine.UI;
using UnityEngine;

public class HighScoreLoader : MonoBehaviour
{
    Text highScoreText;
    void Start()
    {
        highScoreText = GetComponent<Text>();
        int highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        highScoreText.text = "Highest Score: " + highestScore;
    }
}
