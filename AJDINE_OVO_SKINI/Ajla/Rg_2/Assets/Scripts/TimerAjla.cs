using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAjla : MonoBehaviour
{
    public Text timer;
    private float startTime;
    public Text cestitke;
    private bool finnished = false;
 

    void Start()
    {
        startTime = Time.time;
    }

   
    void Update()
    {
        if (finnished)
        {
            return;
        }
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timer.text = minutes +" : " + seconds;
    }


    public void Finnish()
    {
        finnished = true;
        timer.color = Color.grey;
        
    }
}
