using UnityEngine;

public class SawMover : MonoBehaviour
{
    public float moveSpeed = 5f;      // ���ɐi�ރX�s�[�h
    public float rotationSpeed = 360f; // 1�b�Ԃɉ�]����p�x�i�x���j

    private void Start()
    {
        Destroy(gameObject,10f);
    }
    private void Update()
    {
        // ���ֈړ�
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // ���v���ɉ�]
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

       
    }
}
