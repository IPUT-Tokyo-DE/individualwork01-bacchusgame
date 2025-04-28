using UnityEngine;

public class spown : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // プレハブ
    public float spawnInterval = 1.0f;      // 生成間隔（秒）
    public float minX = -8f;                // 最小X座標
    public float maxX = 8f;                 // 最大X座標
    public float spawnY = 6f;               // Y座標（落下開始位置）
    public Vector2 minScale = new Vector2(0.5f, 0.5f);  // 最小サイズ
    public Vector2 maxScale = new Vector2(1.5f, 1.5f);  // 最大サイズ

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);
        GameObject obj = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

        // ランダムサイズの適用
        float randomScaleX = Random.Range(minScale.x, maxScale.x);
        float randomScaleY = Random.Range(minScale.y, maxScale.y);
        obj.transform.localScale = new Vector3(randomScaleX, randomScaleY, 1f);
    }
}
