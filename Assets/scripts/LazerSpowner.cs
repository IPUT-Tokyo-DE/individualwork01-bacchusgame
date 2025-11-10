using UnityEngine;

public class LazerSpowner : MonoBehaviour
{
    public GameObject prefabToSpawn;  // 生成するプレハブ
    public Transform spawnPoint;      // 生成位置
    public float spawnInterval = 6f;  // 生成間隔（秒）

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
