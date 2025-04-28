using UnityEngine;
using System.Collections.Generic;

public class Human : MonoBehaviour
{
    private List<blance> bodyParts = new List<blance>();
    private bool isDead = false; // ���łɎ��S���肳�ꂽ���ǂ���

    private void Start()
    {
        // �q�I�u�W�F�N�g���ׂĂ���blance��T���ă��X�g��
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

        Debug.Log("�S�p�[�c�؂藣�������I�Q�[���I�[�o�[�I");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeState(GameManager.GameState.Result);
        }
    }
}
