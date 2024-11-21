using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 velocity;
    public float walkSpeed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始時一度だけ実行される部分
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ゲーム開始後定期的に実行される部分
        if (characterController.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (velocity.magnitude > 0.1f)
            {
                animator.SetBool("isRunning",true);
                transform.LookAt(transform.position+velocity);
            }
            else
            {
                animator.SetBool("isRunning",false);
            }
            velocity.y += Physics.gravity.y * Time.deltaTime;
            characterController.Move(velocity*walkSpeed*Time.deltaTime);
        }

    }
}
