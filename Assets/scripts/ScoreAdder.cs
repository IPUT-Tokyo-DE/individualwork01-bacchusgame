using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public float scorePerSecond = 10f;
    private float scoreBuffer = 0f; // �����_�̃X�R�A�~�ϗp

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
            // ���t���[���ŃX�R�A�𒙂߂�
            scoreBuffer += scorePerSecond * Time.deltaTime;

            // 1�_�ȏソ�܂����琮�����������Z
            if (scoreBuffer >= 1f)
            {
                int addScore = Mathf.FloorToInt(scoreBuffer);
                GameManager.Instance.AddScore(addScore);
                scoreBuffer -= addScore;
            }
        }
    }
}
