using Unity.VisualScripting;
using UnityEngine;

public class blance : MonoBehaviour
{
    public float targetRot;
    private Rigidbody2D rb2d;
    private walk walkScript;
    private HingeJoint2D hingeJoint;
    private SpriteRenderer spriteRenderer; // �� �ǉ�

    public float force;
    private float originalForce;
    private float currentForce;

    private bool recoveringForce = false;
    private float recoveryTimer = 0f;
    private float recoveryDuration = 1f;

    private bool isDetached = false; // �؂藣���ς݃t���O

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        walkScript = GetComponentInParent<walk>();
        hingeJoint = GetComponent<HingeJoint2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // �� SpriteRenderer���擾
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

            // �ŏ������C�₳����
            if (walkScript != null)
            {
                walkScript.Stun();
            }

            // force��0��
            currentForce = 0f;

            // hingeJoint�����S�ɍ폜
            if (hingeJoint != null)
            {
                Destroy(hingeJoint);
            }

            // �� �����ŐF��ς���
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color32(214, 214, 214, 255);
            }

            Debug.Log($"{gameObject.name} ���؂藣����܂����I");
        }
    }

    public bool IsDetached()
    {
        return isDetached;
    }
}
