using UnityEngine;

public class spown : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // �v���n�u
    public float spawnInterval = 1.0f;      // �����Ԋu�i�b�j
    public float minX = -8f;                // �ŏ�X���W
    public float maxX = 8f;                 // �ő�X���W
    public float spawnY = 6f;               // Y���W�i�����J�n�ʒu�j
    public Vector2 minScale = new Vector2(0.5f, 0.5f);  // �ŏ��T�C�Y
    public Vector2 maxScale = new Vector2(1.5f, 1.5f);  // �ő�T�C�Y

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);
        GameObject obj = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

        // �����_���T�C�Y�̓K�p
        float randomScaleX = Random.Range(minScale.x, maxScale.x);
        float randomScaleY = Random.Range(minScale.y, maxScale.y);
        obj.transform.localScale = new Vector3(randomScaleX, randomScaleY, 1f);
    }
}
