using UnityEngine;

public class BombBlinker : MonoBehaviour
{
    public Transform blinkTarget;
    public float blinkStartDelay = 1.0f;
    public float blinkInterval = 0.5f;
    public float blinkAcceleration = 0.9f;
    public int blinkCountBeforeEnd = 10;
    public float transparentAlpha = 0.3f;

    public GameObject endEffectPrefab;
    public float effectLaunchForce = 5f; // �ǉ��F�G�t�F�N�g���΂���
    public bool destroyOnEnd = true;

    private SpriteRenderer targetRenderer;
    private Color originalColor;

    private void Start()
    {
        if (blinkTarget != null)
        {
            targetRenderer = blinkTarget.GetComponent<SpriteRenderer>();
            if (targetRenderer != null)
            {
                originalColor = targetRenderer.color;
                Invoke(nameof(StartBlink), blinkStartDelay);
            }
            else
            {
                Debug.LogWarning("�w�肳�ꂽblinkTarget��SpriteRenderer�����ĂȂ��I");
            }
        }
        else
        {
            Debug.LogWarning("blinkTarget���w�肳��Ă��܂���I");
        }
    }

    private void StartBlink()
    {
        StartCoroutine(BlinkRoutine());
    }
    public bool R_right = false;
    private System.Collections.IEnumerator BlinkRoutine()
    {
        int blinkCount = 0;
        float currentInterval = blinkInterval;
        bool isTransparent = false;

        while (blinkCount < blinkCountBeforeEnd)
        {
            if (targetRenderer != null)
            {
                Color newColor = targetRenderer.color;
                newColor.a = isTransparent ? 1f : transparentAlpha;
                targetRenderer.color = newColor;
                isTransparent = !isTransparent;
            }

            blinkCount++;

            yield return new WaitForSeconds(currentInterval);

            currentInterval *= blinkAcceleration;
        }
        
        // �Ō�
        if (endEffectPrefab != null)
        {
            GameObject effect = Instantiate(endEffectPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = effect.GetComponent<Rigidbody2D>();
            // �ǉ��F�G�t�F�N�g���������ɔ�΂�
            if (!R_right)
            {
                if (rb != null)
                {
                    rb.AddForce(Vector2.down * effectLaunchForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (rb != null)
                {
                    rb.AddForce(Vector2.left * effectLaunchForce, ForceMode2D.Impulse);
                }
            }
           
        }

        if (destroyOnEnd)
        {
            Destroy(gameObject);
        }
    }
}
