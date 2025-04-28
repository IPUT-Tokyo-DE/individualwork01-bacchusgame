using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;         // 通常の矢プレハブ
    public GameObject laserPrefab;         // レーザー用プレハブ
    public Transform arrowSpawnPoint;      // 発射位置

    public float moveSpeed = 5f;            // 弓の移動速度
    public float waitAfterAlign = 0.5f;     // X合わせた後に待つ時間
    public float spawnInterval = 2f;        // 次までの待機時間
    public float xMin = -8f;                // ランダム移動時の最小X
    public float xMax = 8f;                 // ランダム移動時の最大X

    public Transform playerTransform;      // プレイヤーを指定

    private bool isMoving = false;
    private bool isWaiting = false;
    private int shotCount = 0;
    private bool useRandomTarget = false; // ★ 追加：ランダムモードかどうか

    private blance playerBlance; // ★ 追加：プレイヤーのblance参照

    private void Start()
    {
        // プレイヤーからblanceを取得する
        if (playerTransform != null)
        {
            playerBlance = playerTransform.GetComponent<blance>();
        }

        StartCoroutine(SpawnArrowRoutine());
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x - targetX) < 0.01f)
            {
                isMoving = false;
                StartCoroutine(WaitAndShoot());
            }
        }
    }

    private float targetX;

    private IEnumerator SpawnArrowRoutine()
    {
        while (true)
        {
            // 毎回、playerBlanceが切り離されてるかチェック
            if (playerBlance != null && playerBlance.IsDetached())
            {
                useRandomTarget = true;
            }

            if (useRandomTarget)
            {
                // ランダムターゲット
                targetX = Random.Range(xMin, xMax);
            }
            else
            {
                if (playerTransform != null)
                {
                    targetX = playerTransform.position.x;
                }
            }

            isMoving = true;

            yield return new WaitUntil(() => !isMoving && !isWaiting);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator WaitAndShoot()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitAfterAlign);
        Shoot();
        isWaiting = false;
    }

    private void Shoot()
    {
        GameObject prefabToShoot;

        if ((shotCount % 3) == 2)
        {
            prefabToShoot = laserPrefab;
        }
        else
        {
            prefabToShoot = arrowPrefab;
        }

        Instantiate(prefabToShoot, arrowSpawnPoint.position, Quaternion.identity);

        shotCount++;
    }
}
