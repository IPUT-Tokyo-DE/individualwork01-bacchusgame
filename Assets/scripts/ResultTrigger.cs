using UnityEngine;

public class ResultTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // balance�X�N���v�g�������Ă��邩���ׂ�
            var balance = collision.GetComponent<blance>();

            if (balance != null && balance.IsDetached())
            {
                // balance�������āA���؂藣���ς݂Ȃ牽�����Ȃ�
                return;
            }

            // balance���Ȃ��A�������͐؂藣����ĂȂ��Ȃ烊�U���g��
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ChangeState(GameManager.GameState.Result);
            }
        }
    }
}
