using TMPro;
using UnityEngine;

public class ScoredDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;      // ���݃X�R�A�p
    public TextMeshProUGUI highScoreText;  // �n�C�X�R�A�p

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = $" {GameManager.Instance.Score}";
            highScoreText.text = $" {GameManager.Instance.HighScore}";
        }
    }
}
