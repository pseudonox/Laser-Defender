using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;
    int highestScore = 0;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
        score = 0;
        IncreaseScore(0);
    }

    public void IncreaseScore(int increaseBy)
    {
        score += increaseBy;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("HighestScore", score);
        }
        PlayerPrefs.SetInt("Score", score);
        FindObjectOfType<LevelManager>().LoadLevel("Game Over Screen");
    }

    
}
