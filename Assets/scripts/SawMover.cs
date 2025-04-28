using UnityEngine;

public class SawMover : MonoBehaviour
{
    public float moveSpeed = 5f;      // 左に進むスピード
    public float rotationSpeed = 360f; // 1秒間に回転する角度（度数）

    private void Start()
    {
        Destroy(gameObject,10f);
    }
    private void Update()
    {
        // 左へ移動
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // 時計回りに回転
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

       
    }
}
