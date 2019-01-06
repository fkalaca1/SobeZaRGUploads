using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private Vector3 open, close;
    [SerializeField] private float animationTime;
    private Hashtable hash;
    [SerializeField] private bool opened = false;
    [SerializeField] private type tip;
    private bool on = false;
    public GameObject svjetlo;
    public Text vrijeme;

    private enum type { Slide, Rotate, Light, Ribbon };
    

    void Start()
    {
        hash = iTween.Hash();
        hash.Add("postition", open);
        hash.Add("time", animationTime);
        hash.Add("islocal", true);
       

    }


    public void Akcija()
    {


        if (Input.GetKeyDown(KeyCode.O))
        {
            if (opened)
            {
                hash["position"] = close;
                hash["rotation"] = close;
            }

            else
            {
                hash["position"] = open;
                hash["rotation"] = open;

            }

            opened = !opened;
            switch (tip)
            {

                case type.Slide:
                    iTween.MoveTo(gameObject, hash);
                    break;

                case type.Rotate:
                    
                    iTween.RotateTo(gameObject.transform.parent.gameObject, hash);
                    break;

       

            }



        }

      


    }

    public void Ribbon()
    {


                    GameObject.Find("Meni").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("FPSController").SendMessage("Finnish");
                    GameObject.Find("Izlazak").GetComponent<Text>().text = "Vrijeme: " + vrijeme.text + " \nČestitamo !! Objekat uspješno pronadjen.";

        

       
    }

    public void Light()
    {

        if (on)
        {
            svjetlo.SetActive(false);
            on = false;

        }
        else { svjetlo.SetActive(true); on = true; }
    }



}
