using System.Collections;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    public GameObject sawPrefab;   // �m�R�M���̃v���n�u
    public Transform spawnPoint;   // �E���ɒu�������|�C���g
    public float spawnInterval = 20f;  // �����Ԋu�i�b�j

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
