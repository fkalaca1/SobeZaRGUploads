using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulbasorScript : MonoBehaviour
{
	public GameObject pokupiTekst;
	public GameObject meniButton;
    public GameObject meniLabel;
    public GameObject meniPanel;
    public Text pronadjenVrijeme;
    public GameObject objekatPronadjen; 
    public Text timerText;

	public bool pronadjen = false;
    // Start is called before the first frame update
    void Start()
    {
        pokupiTekst.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {    	
        if (col.gameObject.tag == "Player")
        {
            pokupiTekst.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {    	
        if (col.gameObject.tag == "Player")
        {
           pokupiTekst.SetActive(false);
        }
    }

    void OnTriggerStay(Collider col)
    {    	
        if (col.gameObject.tag == "Player")
        {
        	pokupiTekst.SetActive(pokupiTekst.activeSelf);     	          
        }
    }
}
