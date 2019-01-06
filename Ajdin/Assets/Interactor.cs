using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interactor : MonoBehaviour {

    [SerializeField] private float interactRange;
    private InteractiveObject interactiveObject;
    private Camera cam;
    private RaycastHit hit;
	private bool showGUI = false;
	
	void Start () {
        cam = Camera.main;
	}
	
	void Update () {
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange);
        if (hit.transform) {
            interactiveObject = hit.transform.GetComponent<InteractiveObject>();
			Debug.Log(interactiveObject);
			if(interactiveObject != null){
				showGUI = true;}
			else {
				showGUI = false;
			}
        } else {
            interactiveObject = null;
			showGUI = false;
        }


        if (Input.GetKeyDown(KeyCode.E)) {
            if (interactiveObject) {
                interactiveObject.PerformAction();
            }
        }
    }
	void OnGUI(){
		if(showGUI){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2+25,150,20), "Press 'E' to interact");
		}
	}
}
