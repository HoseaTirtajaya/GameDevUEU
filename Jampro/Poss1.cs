using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poss1 : MonoBehaviour
{
    public Poss2 pos2;
    public bool win;
    public bool winn;

    // Start is called before the first frame update
    void Start()
    {
        win = false;

    }

    // Update is called once per frame
    void Update()
    {
        winn = pos2.win2;
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.tag == "Pos")
        {
            //Debug.Log("Ninja Wins");
            win = true;

        }
    }
}
