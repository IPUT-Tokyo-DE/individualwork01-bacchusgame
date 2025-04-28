using UnityEngine;
using UnityEngine.Rendering.Universal;

public class walk : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb2d;
    public float jumpForce;
    public float touchForce;

    bool jumpFlag = false;

    // 気絶用
    public bool isStunned = false;
    private float stunTimer = 0f;
    public float stunDuration = 2f;

    private void Start()
    {
        anim.SetInteger("action", 0);
    }

    void Update()
    {
        // 気絶中はidle状態で止める
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0f)
            {
                isStunned = false; // 気絶解除
            }
            anim.Play("idle");
            anim.SetInteger("action", 0);
            return; // 気絶中は他の操作無効
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

    // 気絶させるための関数（外から呼ぶ）
    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;
            stunTimer = stunDuration;
        }
    }
}
