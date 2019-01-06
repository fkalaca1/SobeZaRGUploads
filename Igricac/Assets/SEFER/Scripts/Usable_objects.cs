using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Usable_objects : MonoBehaviour {
    public GameObject handImage;
    public GameObject winPanel;
    public Text winScore;
    private bool usable = false;
    
    RaycastHit hit;
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2) && hit.transform.tag == "Usable")
        {
            usable = true;
            handImage.SetActive(true);
        }
        else
        {
            usable = false;
            if(handImage.activeSelf)handImage.SetActive(false);
        }
       
            
    }
    public bool ProvjeraPogodjenog(string []imeObjekta)
    {
        for (int i = 0; i < imeObjekta.Length; i++)
        {
            if (hit.transform != null && imeObjekta != null)
            {
                if (Trigger_Animation.pronadjen && usable == true && hit.transform.gameObject.name == "PomjerajuciPredmet")
                    StartCoroutine(WaitToQuit());
                if (usable == true && hit.transform.gameObject.name == imeObjekta[i])
                    return true;
            }
        }
        return false;
    }
    IEnumerator WaitToQuit()
    {
        yield return new WaitForSeconds(2f);
        winScore.text = "Vrijeme: " + Timer.minute.ToString() + ":" + Timer.sekunde.ToString();
        
        this.gameObject.GetComponentInParent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;

        winPanel.SetActive(true);
        //Prikazi win screen
        PauseGame.Quit();
    }
}
