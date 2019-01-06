using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpaliSvijetlo : MonoBehaviour {
    public Text textToggle;
    private bool delayPassed = true;
    private bool upaljeno = false;
    private void Start()
    {
        RenderSettings.ambientIntensity = 0.12f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player")
        {
            textToggle.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (other.gameObject.transform.tag == "Player" && delayPassed)
            {
                StartCoroutine(UpaliSvjetlo());
                upaljeno = !upaljeno;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            textToggle.enabled = false;
        }
    }
    IEnumerator UpaliSvjetlo()
    {
        delayPassed = false;
        if (!upaljeno)
            RenderSettings.ambientIntensity = 1f;
        else
            RenderSettings.ambientIntensity = 0.12f;
        
        yield return new WaitForSeconds(0.1f);
        delayPassed = true;
    }
}
