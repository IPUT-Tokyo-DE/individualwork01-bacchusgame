using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;         // �ʏ�̖�v���n�u
    public GameObject laserPrefab;         // ���[�U�[�p�v���n�u
    public Transform arrowSpawnPoint;      // ���ˈʒu

    public float moveSpeed = 5f;            // �|�̈ړ����x
    public float waitAfterAlign = 0.5f;     // X���킹����ɑ҂���
    public float spawnInterval = 2f;        // ���܂ł̑ҋ@����
    public float xMin = -8f;                // �����_���ړ����̍ŏ�X
    public float xMax = 8f;                 // �����_���ړ����̍ő�X

    public Transform playerTransform;      // �v���C���[���w��

    private bool isMoving = false;
    private bool isWaiting = false;
    private int shotCount = 0;
    private bool useRandomTarget = false; // �� �ǉ��F�����_�����[�h���ǂ���

    private blance playerBlance; // �� �ǉ��F�v���C���[��blance�Q��

    private void Start()
    {
        // �v���C���[����blance���擾����
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
            // ����AplayerBlance���؂藣����Ă邩�`�F�b�N
            if (playerBlance != null && playerBlance.IsDetached())
            {
                useRandomTarget = true;
            }

            if (useRandomTarget)
            {
                // �����_���^�[�Q�b�g
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
