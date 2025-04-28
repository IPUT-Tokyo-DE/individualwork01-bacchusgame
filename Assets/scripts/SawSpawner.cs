using System.Collections;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    public GameObject sawPrefab;   // ノコギリのプレハブ
    public Transform spawnPoint;   // 右側に置く生成ポイント
    public float spawnInterval = 20f;  // 生成間隔（秒）

    private void Start()
    {
        StartCoroutine(SpawnSawRoutine());
    }

    private IEnumerator SpawnSawRoutine()
    {
        while (true)
        {
            SpawnSaw();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnSaw()
    {
        Instantiate(sawPrefab, spawnPoint.position, Quaternion.identity);
    }
}
