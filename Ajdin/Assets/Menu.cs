using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Menu : MonoBehaviour
{
    public GameObject pausePanel;
	public GameObject tutorial;
	private FirstPersonController fpc;
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_Paused;
	private bool start;

void Start(){
	MenuOff();
	tutorial.SetActive(true);
	start = true;
    m_TimeScaleRef = Time.timeScale;
	Time.timeScale = 0f;
	fpc = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
}
    private void MenuOn ()
    {
		pausePanel.SetActive(true);
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;
		
        m_Paused = true;
    }


    public void MenuOff ()
    {
		pausePanel.SetActive(false);
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        m_Paused = false;
    }


    public void OnMenuStatusChange ()
    {
        if (!m_Paused)
        {
            MenuOn();
        }
        else if (m_Paused)
        {
            MenuOff();
        }
    }


#if !MOBILE_INPUT
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.M))
		{
		    OnMenuStatusChange();
            Cursor.visible = m_Paused;
			
		} else if( start && Input.anyKey){
			start = false;
			tutorial.SetActive(false);
			Time.timeScale = m_TimeScaleRef;
		}
		if(m_Paused || start){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			fpc.enabled = false;
		} else {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			fpc.enabled = true;
		}
	}
#endif
	void LateUpdate(){
		
	}
}
