using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
	public GameObject jas1;
	public GameObject jas2;
    public float throwForce = 10;
    bool beingCarried = false;
    public AudioClip[] soundToPlay;
    private AudioSource audio;
    public int dmg;
    private bool touched = false;
	private bool showGUI = false;
	private bool showThrow = false;
	private bool throwObject;
	private RaycastHit hit;
	private Camera cam;
	private float interactRange = 1.4f;
    void Start()
    {
        audio = GetComponent<AudioSource>();
		cam=Camera.main;
    }

    void Update()
    {
		Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange);
		GameObject go = null;
		if(hit.transform){
			if(hit.collider.gameObject == jas1 || hit.collider.gameObject ==jas2 && !beingCarried){
				showGUI=true;
				showThrow=false;
			} else {
				showGUI = false;
			}
		} else {
			showGUI = false;
			showThrow = false;
		}
        if (Input.GetKeyDown(KeyCode.E) && showGUI)	
        {
            hit.rigidbody.isKinematic = true;
            hit.transform.parent = playerCam;
            beingCarried = true;
			showGUI=false;
			showThrow = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                hit.rigidbody.isKinematic = false;
                hit.transform.parent = null;
                beingCarried = false;
                touched = false;
				showThrow = false;
            }
            if (Input.GetMouseButtonDown(0))
                {
                    hit.rigidbody.isKinematic = false;
                    hit.transform.parent = null;
                    beingCarried = false;
					showThrow = false;
                    hit.rigidbody.AddForce(playerCam.forward * throwForce);
                RandomAudio();
                }
                else if (Input.GetMouseButtonDown(1))
                {
                hit.rigidbody.isKinematic = false;
                hit.transform.parent = null;
                beingCarried = false;
				showThrow = false;
                }
            }
        }
    void RandomAudio()
    {
        if (audio.isPlaying){
            return;
                }
        audio.Play();

    }
   void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
	void OnGUI(){
		if(showThrow){
			Debug.Log(beingCarried);
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2+25,300,20), "Press Left-Mouse Click to throw");
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2+50,300,20), "Press Right-Mouse Click to drop");
		} else if (showGUI) {
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2+25,150,20), "Press 'E' to interact	");
		}
	}
}