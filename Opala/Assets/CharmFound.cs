using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmFound : MonoBehaviour
{
	private float m_TimeScaleRef;
	private RaycastHit hit;
	private Camera cam;
	private float interactRange = 2.5f;
	private bool showGUI = false;
	private bool showExit = false;
	private bool pressedE = false;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange);
		if(hit.transform && !showExit){
			if(hit.transform.GetComponent<CharmFound>() != null){
				if(Input.GetKeyDown(KeyCode.E)){
					showExit=true;
					showGUI=false;
					m_TimeScaleRef = Time.timeScale;
					Time.timeScale = 0f;
				}
				if(!showExit)showGUI=true;
			}
		}
        
    }
	void OnGUI(){
		if(showGUI){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2+50,300,20), "Press 'E' to interact");
		} else if(showExit){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2+70,300,20), "Press M to leave");
		}
	}
}
