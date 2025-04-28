using UnityEngine;
using System.Collections.Generic;

public class Human : MonoBehaviour
{
    private List<blance> bodyParts = new List<blance>();
    private bool isDead = false; // すでに死亡判定されたかどうか

    private void Start()
    {
        // 子オブジェクトすべてからblanceを探してリスト化
        blance[] parts = GetComponentsInChildren<blance>();
        bodyParts.AddRange(parts);
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        bool allDetached = true;

        foreach (var part in bodyParts)
        {
            if (part != null && !part.IsDetached())
            {
                allDetached = false;
                break;
            }
        }

        if (allDetached)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isDead = true;

        Debug.Log("全パーツ切り離し完了！ゲームオーバー！");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeState(GameManager.GameState.Result);
        }
    }
}
