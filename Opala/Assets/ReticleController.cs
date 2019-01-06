using UnityEngine;
using System.Collections;

public class ReticleController : MonoBehaviour {

    private GameObject defaultIcon, interactIcon;

	void Start () {
        defaultIcon = GameObject.Find("DefaultIcon");
        interactIcon = GameObject.Find("InteractIcon");
        interactIcon.SetActive(false);
	}

    public void ShowIcon(bool isInteractIcon) {
        defaultIcon.SetActive(!isInteractIcon);
        interactIcon.SetActive(isInteractIcon);
    }
}
