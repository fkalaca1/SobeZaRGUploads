using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Animation : MonoBehaviour {

    Animation animacija;
    public Usable_objects Use;
    public string[] taggedUsableObjectsNames;
    public bool otvorena = false;
    public string nazivAnimacije;
    private bool ugasiSvijetlo=false;
    public static bool pronadjen = false;
    private Light hintLight;
    // Use this for initialization
    void Start()
    {
        hintLight = GameObject.Find("HintLight").GetComponent<Light>();
        animacija = GetComponent<Animation>();
        for (int i = 0; i < taggedUsableObjectsNames.Length; i++)
        {
            switch (taggedUsableObjectsNames[i])
            {
                case "Box06":
                case "Box07":
                case "Box08":
                case "Rectangle26":
                    ugasiSvijetlo = true;
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Use.ProvjeraPogodjenog(taggedUsableObjectsNames) && !animacija.IsPlaying(nazivAnimacije))
        {
            //Pritisni tipku da pokrenes animaciju
            if (Input.GetButtonDown("Fire1") && !otvorena)
            {
                if (ugasiSvijetlo) 
                    hintLight.enabled = false;
                if (taggedUsableObjectsNames[0] == "PomjerajuciPredmet")
                {
                    pronadjen = true;
                }
                animacija[nazivAnimacije].speed = 1;
                animacija[nazivAnimacije].time = 0;
                animacija.Play();
                otvorena = true;
            }
            else if (Input.GetButtonDown("Fire1") && otvorena)
            {

                animacija[nazivAnimacije].speed = -1f;
                animacija[nazivAnimacije].time = animacija[nazivAnimacije].length;
                animacija.Play();
                otvorena = false;
            }
        }
    }
}
