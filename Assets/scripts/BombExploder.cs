using UnityEngine;

public class BombExploder : MonoBehaviour
{
    public GameObject explosionEffectPrefab; // ­GtFNgΜPrefab

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

        Destroy(gameObject); // e{Μπν
    }
}
