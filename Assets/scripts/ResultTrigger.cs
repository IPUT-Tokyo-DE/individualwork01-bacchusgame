using UnityEngine;

public class ResultTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // balanceスクリプトを持っているか調べる
            var balance = collision.GetComponent<blance>();

            if (balance != null && balance.IsDetached())
            {
                // balanceがあって、かつ切り離し済みなら何もしない
                return;
            }

            // balanceがない、もしくは切り離されてないならリザルトへ
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ChangeState(GameManager.GameState.Result);
            }
        }
    }
}
