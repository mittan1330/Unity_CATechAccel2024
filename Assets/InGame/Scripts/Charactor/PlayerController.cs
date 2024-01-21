using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] float speed = 1f;
    private Vector3 _moveInput;

    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsOwner)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            // ????(???)??????????
            MoveServerRpc(h, v);
        }
        
        if (IsServer)
        {
            Move();
            // ????????????????
            if (transform.position.y < -10.0)
            {
                transform.position = new Vector3(Random.Range(-3, 3), 3, Random.Range(-3, 3));
            }
        }
    }

    void Move()
    {
        transform.position += _moveInput * Time.deltaTime * speed;
        animator.SetFloat("Speed", _moveInput.magnitude);
    }
    
    [ServerRpc]
    void MoveServerRpc(float vertical, float horizontal)
    {
        // ???????(???)????????
        _moveInput = new Vector3(horizontal, 0, vertical);
        if (_moveInput.magnitude > 0f)
            transform.LookAt(transform.position + _moveInput);
        
    }
}