using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillscr : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float dashSpeed = 12.0f;
    public float dashcd = 3.0f;

    public float skillcd = 5.0f;
    public bool cooldown = false;
    public bool dashcooldown = false;



    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            //Debug.Log("Nyentuh koq kak");
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            speedDash();
            //print("Horizontal: " + Input.GetAxis("Horizontal"));
            //print("Vertical: " + Input.GetAxis("Vertical"));

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        DoubleJump();

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

    }

    void DoubleJump()
    {
        if ((!characterController.isGrounded) && (cooldown == false) && (skillcd > 0))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Skill Activated!!");
                moveDirection.y = jumpSpeed;
                cooldown = true;

                moveDirection.y -= gravity * Time.deltaTime;
            }
        }
        if (cooldown == true)
        {
            skillcd -= Time.deltaTime;
            if (skillcd < 0)
            {
                skillcd = 5f;
                cooldown = false;
            }
        }
    }

    void speedDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcooldown == false)
        {
            Debug.Log("DASSHHHH!!!!");
            moveDirection *= dashSpeed;
            dashcooldown = true;
        }
        if(dashcooldown == true )
        {
            dashcd -= Time.deltaTime;
            if(dashcd < 0)
            {
                dashcd = 3f;
                dashcooldown = false;
            }
        }
    }
}
