using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer : MonoBehaviour {
    public int jawaban;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void button()
    {
        if (this.randomButton())
        {
            jawaban = 1;
        }
        else
        {
            jawaban = 0;
        }
        Debug.Log(jawaban);
    }
    
    public bool randomButton()
    {
        float RandomJawaban = Random.Range(0.00f, 1.00f);
        return (RandomJawaban >= 0.0f && RandomJawaban <= 0.5f);
    }

    public void question()
    {   
        string[] question = new string[3];
        question[0] = "Apakah Jakarta adalah ibukota?";
        question[1] = "Apakah bahasa C# lebih sukar dari C++?";
        question[2] = "Apakah C# itu bahasa pemograman?";
        

    }
}
