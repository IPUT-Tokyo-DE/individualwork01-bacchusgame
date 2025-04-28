using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public float scorePerSecond = 10f;
    private float scoreBuffer = 0f; // 小数点のスコア蓄積用

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
            // 毎フレームでスコアを貯める
            scoreBuffer += scorePerSecond * Time.deltaTime;

            // 1点以上たまったら整数分だけ加算
            if (scoreBuffer >= 1f)
            {
                int addScore = Mathf.FloorToInt(scoreBuffer);
                GameManager.Instance.AddScore(addScore);
                scoreBuffer -= addScore;
            }
        }
    }
}
