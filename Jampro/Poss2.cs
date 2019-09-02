using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poss2 : MonoBehaviour
{
    public Poss1 poss11;
    public bool win2;
    public bool win3;


    // Start is called before the first frame update
    void Start()
    {
        win2 = true;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

     void OnTriggerExit(Collider trig)
    {
        if(trig.tag == "Pos")
        {
            //Debug.Log("Ghoul Wins");

        }
    }
}
