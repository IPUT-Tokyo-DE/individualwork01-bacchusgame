using TMPro;
using UnityEngine;

public class ScoredDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;      // 現在スコア用
    public TextMeshProUGUI highScoreText;  // ハイスコア用

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = $" {GameManager.Instance.Score}";
            highScoreText.text = $" {GameManager.Instance.HighScore}";
        }
    }
}
