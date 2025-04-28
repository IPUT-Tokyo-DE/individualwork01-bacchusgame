using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour
{
    public float blinkStartDelay = 1.0f;  // 点滅開始までの待機
    public float blinkInterval = 0.5f;    // 最初の点滅間隔
    public float blinkAcceleration = 0.9f; // 点滅間隔の縮小率
    public int blinkCountBeforeExplode = 10; // 爆発までの点滅回数
    public GameObject explosionEffectPrefab; // 爆発エフェクトのPrefab
    public float transparentAlpha = 0.3f; // 半透明時の透明度
    public GameObject explosionObj;//爆発判定

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
        // 点滅開始まで待機
        yield return new WaitForSeconds(blinkStartDelay);

        int blinkCount = 0;
        float currentInterval = blinkInterval;
        bool isTransparent = false;

        while (blinkCount < blinkCountBeforeExplode)
        {
            // 透明度切り替え
            Color newColor = spriteRenderer.color;
            if (isTransparent)
                newColor.a = 1f;  // 元の不透明
            else
                newColor.a = transparentAlpha;  // 半透明

            spriteRenderer.color = newColor;
            isTransparent = !isTransparent;

            blinkCount++;

            yield return new WaitForSeconds(currentInterval);

            // 徐々に点滅スピードアップ
            currentInterval *= blinkAcceleration;
        }

        // 爆発！
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
