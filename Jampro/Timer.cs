using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    public int timeLeft = 480;
    public Text timerup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        timerup.text = ("Time Left: " + timeLeft);
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
