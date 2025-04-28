using UnityEngine;
using UnityEngine.Rendering.Universal;

public class walk : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public float touchForce;

    bool jumpFlag = false;

    // �C��p
    public bool isStunned = false;
    private float stunTimer = 0f;
    public float stunDuration = 2f;

    private void Start()
    {
        anim.SetInteger("action", 0);
    }

    void Update()
    {
        // �C�⒆��idle��ԂŎ~�߂�
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0f)
            {
                isStunned = false; // �C�����
            }
            anim.Play("idle");
            anim.SetInteger("action", 0);
            return; // �C�⒆�͑��̑��얳��
        }

        float horizotalValue = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("jump");
            jumpFlag = true;
        }
        else if (jumpFlag)
        {
            JumpAction();
            return;
        }
        else if (horizotalValue != 0)
        {
            UnitWalk(horizotalValue);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Attack();
            return;
        }
        else
        {
            anim.Play("idle");
            anim.SetInteger("action", 0);
        }
    }

    void JumpAction()
    {
        rb2d.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        jumpFlag = false;
    }

    void Attack()
    {
        anim.Play("attack");
    }

    void UnitWalk(float horizotalValuehorizotalValue)
    {
        if (horizotalValuehorizotalValue > 0)
        {
            anim.SetInteger("action", 2);
            rb2d.AddForce(Vector2.right * touchForce * Time.deltaTime);
        }
        else
        {
            anim.SetInteger("action", 1);
            rb2d.AddForce(Vector2.left * touchForce * Time.deltaTime);
        }
    }

    // �C�₳���邽�߂̊֐��i�O����Ăԁj
    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;
            stunTimer = stunDuration;
        }
    }
}
