using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float playerHP;

    [SerializeField]
    Rigidbody rigidBody;
    [SerializeField]
    Animator animator;
    [SerializeField]
    float jumpPower = 20;
    [SerializeField]
    float movePower = 20;
    [SerializeField]
    float groundCheckRadius = 0.4f;
    [SerializeField]
    float groundCheckOffsetY = 0.45f;
    [SerializeField]
    float groundCheckDistance = 0.2f;
    [SerializeField]
    LayerMask groundLayers = 0;

    bool isGrounded = false;
    bool isMoved = false;


    private void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        playerHP = 100f;
    }

    void Update()
    {
        GetInput();
        UpdateAnimator();
        UpdateAnimator(isMoved);
    }

    // 入力受付
    void GetInput()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if(isGrounded)
        {
            transform.position += MoveVector(out bool isMove) * Time.deltaTime;
            isMoved = isMove;
        }
        else
        {
            isMoved = false;
        }
    }
    //　移動方向の取得
    private Vector3 MoveVector(out bool isMove)
    {
        Vector3 moveVector = Vector3.zero;

        isMove = false;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVector += new Vector3(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVector += new Vector3(0, 0, -0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector += new Vector3(-0.1f, 0, 0);
        }
        if (moveVector != Vector3.zero)
        {
            isMove = true;
        }

        return moveVector;
    }

    // ジャンプ
    void Jump()
    {
        rigidBody.AddForce(jumpPower * Vector2.up, ForceMode.Impulse);
    }

    // アニメーターの更新
    void UpdateAnimator()
    {
        animator.SetBool("Grounded", isGrounded);
    }
    void UpdateAnimator(bool isMove)
    {
        animator.SetBool("Moved", isMove);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
