using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour
{
    public float blinkStartDelay = 1.0f;  // �_�ŊJ�n�܂ł̑ҋ@
    public float blinkInterval = 0.5f;    // �ŏ��̓_�ŊԊu
    public float blinkAcceleration = 0.9f; // �_�ŊԊu�̏k����
    public int blinkCountBeforeExplode = 10; // �����܂ł̓_�ŉ�
    public GameObject explosionEffectPrefab; // �����G�t�F�N�g��Prefab
    public float transparentAlpha = 0.3f; // ���������̓����x
    public GameObject explosionObj;//��������

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        StartCoroutine(BlinkAndExplode());
    }

    private IEnumerator BlinkAndExplode()
    {
        // �_�ŊJ�n�܂őҋ@
        yield return new WaitForSeconds(blinkStartDelay);

        int blinkCount = 0;
        float currentInterval = blinkInterval;
        bool isTransparent = false;

        while (blinkCount < blinkCountBeforeExplode)
        {
            // �����x�؂�ւ�
            Color newColor = spriteRenderer.color;
            if (isTransparent)
                newColor.a = 1f;  // ���̕s����
            else
                newColor.a = transparentAlpha;  // ������

            spriteRenderer.color = newColor;
            isTransparent = !isTransparent;

            blinkCount++;

            yield return new WaitForSeconds(currentInterval);

            // ���X�ɓ_�ŃX�s�[�h�A�b�v
            currentInterval *= blinkAcceleration;
        }

        // �����I
        Explode();
    }

    private void Explode()
    {
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            GameObject obj = Instantiate(explosionObj, transform.position, Quaternion.identity);
            Destroy(obj,0.5f);
        }
        Destroy(gameObject);
    }
}
