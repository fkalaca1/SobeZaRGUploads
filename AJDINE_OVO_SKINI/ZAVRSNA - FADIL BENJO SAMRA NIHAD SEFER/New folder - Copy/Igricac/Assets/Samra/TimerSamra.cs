using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSamra : MonoBehaviour
{
   public Text timer;
    public float startTime;
    private bool kraj = false;
    //public string nazivScene;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (kraj)
        {
            return;
        }
        float vrijeme = Time.time - startTime;
        string min = ((int)vrijeme / 60).ToString();
        string sec = (vrijeme % 60).ToString("f0");
        timer.text = min + ":" + sec;

        int minuta = (int)vrijeme / 60;

        if (Input.GetKey(KeyCode.M))
        {
            Kraj();
        }
    }

    public void Kraj()
    {
        kraj = true;
        timer.color = Color.red;
         SceneManager.LoadScene("zavrsna");
        
    }
}
