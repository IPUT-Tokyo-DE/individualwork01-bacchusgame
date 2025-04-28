using Unity.VisualScripting;
using UnityEngine;

public class blance : MonoBehaviour
{
    public float targetRot;
    private Rigidbody2D rb2d;
    private walk walkScript;
    private HingeJoint2D hingeJoint;
    private SpriteRenderer spriteRenderer; // ★ 追加

    public float force;
    private float originalForce;
    private float currentForce;

    private bool recoveringForce = false;
    private float recoveryTimer = 0f;
    private float recoveryDuration = 1f;

    private bool isDetached = false; // 切り離し済みフラグ

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        walkScript = GetComponentInParent<walk>();
        hingeJoint = GetComponent<HingeJoint2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // ★ SpriteRendererを取得
        originalForce = force;
        currentForce = force;
    }

    private void Update()
    {
        if (walkScript != null && !isDetached)
        {
            if (walkScript.isStunned)
            {
                currentForce = 0f;
                recoveringForce = false;
            }
            else
            {
                if (!recoveringForce && currentForce == 0f)
                {
                    recoveringForce = true;
                    recoveryTimer = 0f;
                }
            }
        }

        if (recoveringForce)
        {
            recoveryTimer += Time.deltaTime;
            float t = recoveryTimer / recoveryDuration;
            t = Mathf.Clamp01(t);
            currentForce = Mathf.Lerp(0f, originalForce, t);

            if (t >= 1f)
            {
                recoveringForce = false;
            }
        }

        rb2d.MoveRotation(Mathf.LerpAngle(rb2d.rotation, targetRot, currentForce * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bomb") && !isDetached)
        {
            isDetached = true;

            // 最初だけ気絶させる
            if (walkScript != null)
            {
                walkScript.Stun();
            }

            // forceを即0に
            currentForce = 0f;

            // hingeJointを完全に削除
            if (hingeJoint != null)
            {
                Destroy(hingeJoint);
            }

            // ★ ここで色を変える
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color32(214, 214, 214, 255);
            }

            Debug.Log($"{gameObject.name} が切り離されました！");
        }
    }

    public bool IsDetached()
    {
        return isDetached;
    }
}
