using UnityEngine;
using System.Collections;

public class otvori_tablu : MonoBehaviour {
    Animation animacija_table;
    public Usable_objects Use;
    private string[] imenaObjekata = { "Board_Small" };
    public bool otvorena = false;
	// Use this for initialization
	void Start () {
        animacija_table = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Use.ProvjeraPogodjenog(imenaObjekata) && !animacija_table.IsPlaying("Otvori_tablu"))
        {
            //Pritisni tipku da pokrenes animaciju
            if (Input.GetButtonDown("Fire1")  && !otvorena)
            {
                animacija_table["Otvori_tablu"].speed = 1;
                animacija_table["Otvori_tablu"].time = 0;
                animacija_table.Play();
                otvorena = true;
            }
            else if (Input.GetButtonDown("Fire1") && otvorena)
            {
                animacija_table["Otvori_tablu"].speed = -1f;
                animacija_table["Otvori_tablu"].time = animacija_table["Otvori_tablu"].length;
                animacija_table.Play();
                otvorena = false;
            }
        }
	}
}
