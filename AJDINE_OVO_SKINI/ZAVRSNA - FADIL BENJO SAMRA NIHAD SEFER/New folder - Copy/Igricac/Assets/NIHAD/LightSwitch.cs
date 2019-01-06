using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LightSwitch : MonoBehaviour
{
    public GameObject light;
    public GameObject textO;
    public GameObject textC;
    public GameObject meniButton;
    public GameObject meniLabel;
    public GameObject meniPanel;
    public Text timerText;
    private float startTime;
    private bool pressedM = false;

    public GameObject panel1;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject slikaKontura;

    public GameObject hintLight;
    public GameObject pokupiTekst;

    public GameObject objekatPronadjen;
    public Text pronadjenVrijeme;

    public GameObject testniBulbasorObjekat;

    public bool pronadjen = false;

    void Start()
    {
    	light.SetActive(false);
        textC.SetActive(false);
        textO.SetActive(false);
        meniButton.SetActive(false);
        meniPanel.SetActive(false);
        meniLabel.SetActive(false);
        hintLight.SetActive(false);
        objekatPronadjen.SetActive(false);

        startTime = Time.time;
    }

    void Update(){

    	if(pronadjen || pressedM){
    		
    		Cursor.visible = true;
    		Cursor.lockState = CursorLockMode.None;
    	}

    	float t = Time.time - startTime;

    	string minutes = ((int) t/60).ToString();
    	string seconds = (t%60).ToString("f0");

    	if(Int32.Parse(minutes) >= 1){
    			hintLight.SetActive(true);
    	}

    	if(Int32.Parse(seconds) < 10){
    		if(Int32.Parse(minutes) < 10){
    			timerText.text = "0" + minutes + ":" + "0" + seconds;
    		}
    		else{
    			timerText.text = minutes + ":" + "0" + seconds;
    		}  		
    	}

    	else{

    		if(Int32.Parse(minutes) < 10){
    			timerText.text = "0" + minutes + ":" + seconds;
    		}
    		else{
    			timerText.text =  minutes + ":" + seconds;
    		}		
    	}
    	

    	if(Input.GetKeyDown(KeyCode.M)){

    		meniButton.SetActive(!meniButton.activeSelf);
    		meniPanel.SetActive(!meniPanel.activeSelf);
        	meniLabel.SetActive(!meniLabel.activeSelf);

        	Cursor.visible = !Cursor.visible;
    		Cursor.lockState = CursorLockMode.None;

    		pressedM = !pressedM;
    	}

    	if(Input.GetKeyDown(KeyCode.X)){
        	
    		panel1.SetActive(false);
    		text6.SetActive(false);
    		text5.SetActive(false);
    		text4.SetActive(false);
    		text3.SetActive(false);
    		text2.SetActive(false);
    		text1.SetActive(false);
    		slikaKontura.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.P) && pokupiTekst.activeSelf){

        	pronadjen = true;
        	objekatPronadjen.SetActive(true);
        	Cursor.visible = true;
        	meniPanel.SetActive(true);
        	meniLabel.SetActive(true);
        	meniButton.SetActive(true);
        	pronadjenVrijeme.text = "Vrijeme: " + timerText.text;
        	pokupiTekst.SetActive(false);
        	testniBulbasorObjekat.SetActive(false);
        } 
    }

    void OnTriggerEnter(Collider col)
    {    	
        if (col.gameObject.tag == "Player")
        {
            textO.SetActive(light.activeSelf);
            textC.SetActive(!light.activeSelf);
        }
    }

    void OnTriggerExit(Collider col)
    {    	
        if (col.gameObject.tag == "Player")
        {
            textO.SetActive(false);
            textC.SetActive(false);
        }
    }

    void OnTriggerStay(Collider col)
    {    	
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
            	
                // toggle the light. If off turn it on,  if on turn it off
                light.SetActive(!light.activeSelf);
                // update the texts based on the new active state.
                textO.SetActive(light.activeSelf);
                textC.SetActive(!light.activeSelf);

            }
        }
    }
}