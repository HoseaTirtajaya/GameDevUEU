using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    public Collider poss;
    public Rigidbody rb2;
    public Vector3 jump2;
    public CameraCtr ctr;
    public bool grounded2 = false;

    public float timer2 = 1f;
    public bool spamtimer2 = false;

    public float dashSpeed2 = 12.0f;
    public float dashcd2 = 3.0f;

    public float skillcd2 = 5.0f;
    public bool cooldown2 = false;
    public bool dashcooldown2 = false;
    public float dedmeter2;


    // Start is called before the first frame update
    void Start()
    {
        poss = GetComponentInChildren<BoxCollider>();
        rb2 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dedmeter2 = ctr.deadMetre;
        //Debug.Log(dedmeter2);
        rb2.constraints = RigidbodyConstraints.FreezeRotation;

        if ((Input.GetKeyDown(KeyCode.UpArrow)) && (grounded2 == true) && (spamtimer2 == false))
        {
            //Debug.Log("Hi there!");
            rb2.AddForce(0f, 10f, 10f, ForceMode.Impulse);
            spamtimer2 = true;
        }
        DoubleJump2();
        if (spamtimer2 == true)
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
            {
                timer2 = 0.8f;
                spamtimer2 = false;
            }
        }
        speedDash2();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded2 = true;

        }
        if(col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("player1win");
        }
        if(col.gameObject.tag == "Win")
        {
            rb2.constraints = RigidbodyConstraints.FreezePosition;
            SceneManager.LoadScene("player2win");
        }
    }

    private void OnCollisionExit(Collision coli)
    {
        if (coli.gameObject.tag == "Ground")
        {
            grounded2 = false;
        }
    }

    private void OnTriggerExit(Collider trigg)
    {
        if(trigg.gameObject.tag == "pos1")
        {
            Debug.Log("Juara 2 Gan");
        }
    }

    void DoubleJump2()
    {
        if ((grounded2 == false) && (cooldown2 == false) && (skillcd2 > 0))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Debug.Log("Skill Activated!!");
                rb2.AddForce(0f, 5f, 2f, ForceMode.Impulse);
                cooldown2 = true;
            }
        }
        if (cooldown2 == true)
        {
            skillcd2 -= Time.deltaTime;
            if (skillcd2 < 0)
            {
                skillcd2 = 5f;
                cooldown2 = false;
            }
        }
    }

    void speedDash2()
    {
        if ((Input.GetKeyDown(KeyCode.RightShift)) && (dashcooldown2 == false) && (grounded2 == false))
        {
            //Debug.Log("DASSHHHH!!!!");
            rb2.AddForce(0f, 1f, 75f);
            dashcooldown2 = true;
        }
        if (dashcooldown2 == true)
        {
            dashcd2 -= Time.deltaTime;
            if (dashcd2 < 0)
            {
                dashcd2 = 3f;
                dashcooldown2 = false;
            }
        }
    }
}
