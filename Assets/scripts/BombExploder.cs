using UnityEngine;

public class BombExploder : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // 爆発エフェクトのPrefab

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
            Explode();
        
    }

    private void Explode()
    {
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // 爆弾本体を削除
    }
}
