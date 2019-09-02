using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Collider pos;
    public Rigidbody rb;
    public Vector3 jump;
    public bool grounded = false;
    public CameraCtr cr;

    public float timer = 1f;
    public bool spamtimer = false;

    public float dashSpeed = 12.0f;
    public float dashcd = 3.0f;

    public float skillcd = 5.0f;
    public bool cooldown = false;
    public bool dashcooldown = false;
    public bool win = true;

    public float dedmeter;
    


    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponentInChildren<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dedmeter = cr.deadMetre;
        //Debug.Log(dedmeter);
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if ((Input.GetKeyDown(KeyCode.Space)) && (grounded == true) && (spamtimer == false))
        {
            Debug.Log("Hi there!");
            rb.AddForce(0f, 10f, 10f, ForceMode.Impulse);
            spamtimer = true;
        }
        DoubleJump();
        if (spamtimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0.8f;
                spamtimer = false;
            }
        }

        speedDash();
    }

    private void OnCollisionEnter(Collision col)
    {
      
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;

        }

        if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("player1win");
        }

        if(col.gameObject.tag == "Win")
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            SceneManager.LoadScene("player2win"); 
        }
    }

    private void OnCollisionExit(Collision coli)
    {
        if (coli.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }


    void DoubleJump()
    {
        if ((grounded == false) && (cooldown == false) && (skillcd > 0))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Skill Activated!!");
                rb.AddForce(0f, 10f, 2f, ForceMode.Impulse);
                cooldown = true;
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
        if ((Input.GetKeyDown(KeyCode.LeftShift)) && (dashcooldown == false) && (grounded == false))
        {
            Debug.Log("DASSHHHH!!!!");
            rb.AddForce(0f, 1f, 75f);
            dashcooldown = true;
        }
        if (dashcooldown == true)
        {
            dashcd -= Time.deltaTime;
            if (dashcd < 0)
            {
                dashcd = 3f;
                dashcooldown = false;
            }
        }
    }
}
