using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameMenagment : MonoBehaviour {
    public GameObject helpPanel;
    // Use this for initialization
    void Awake () {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.gameObject.GetComponent<PauseGame>().enabled = false;
        this.gameObject.GetComponent<FirstPersonController>().enabled = false;
        helpPanel.SetActive(true);
    }
	// Update is called once per frame
	public void Continue()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.GetComponent<PauseGame>().enabled = true;
        this.gameObject.GetComponent<FirstPersonController>().enabled = true;
        helpPanel.SetActive(false);
    }
}
