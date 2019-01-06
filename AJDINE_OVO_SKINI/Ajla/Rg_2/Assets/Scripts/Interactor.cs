using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    private Camera cam;
    private RaycastHit hit;
    [SerializeField] private float range;
    private InteractiveObject objekat;
    public Text upute;
    public Text vrijeme;
    public GameObject svjetlo;
    
   

    void Start()
    {
        cam = Camera.main;
        GameObject.Find("Meni").GetComponent<Canvas>().enabled = false;
        svjetlo.SetActive(false);


    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject.Find("Pocetno").GetComponent<Text>().text = "";
            Destroy(GameObject.Find("Image").GetComponent<RawImage>());
            //Destroy(pocetno);

        }

        if (Input.GetKeyDown(KeyCode.M))
        {

            GameObject.Find("Pocetno").GetComponent<Text>().text = "";
            Destroy(GameObject.Find("Image").GetComponent<RawImage>());
            GameObject.Find("Meni").GetComponent<Canvas>().enabled = true;
            GameObject.Find("FPSController").SendMessage("Finnish");
            GameObject.Find("Izlazak").GetComponent<Text>().text = "Vrijeme: " + vrijeme.text + " \nObjekat nije pronadjen. Više sreće drugi put.";
            
        }



        if (vrijeme.text.Equals("0 : 10.00"))
        {
            svjetlo.SetActive(true);
        }



        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range);

        if (hit.transform)
        {

            objekat = hit.transform.GetComponent<InteractiveObject>();

            if (objekat != null)
            {
                if (objekat.name == "ladica2" || objekat.name == "ladica3" || objekat.name == "ladica4")
                    upute.text = "Klikni O za otvaranje ladice";
                if (objekat.name == "vrata" || objekat.name == "vrata2")
                    upute.text = "Klikni O za otvaranje vrata";
                if (objekat.name == "jastuk")
                    upute.text = "Klikni O za pomjeranje jastuka";
                if (objekat.name == "rbaobj")
                    upute.text = "Klikni R za uzimanje objekta";
                if (objekat.name == "svjetlo")
                    upute.text = "Klikni L za paljenje svjetla";
            }


            if (Input.GetKeyDown(KeyCode.O))
            {

                if (objekat)
                {
                    
                    objekat.Akcija();
                }
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {

                if (objekat)
                {
                    objekat.Ribbon();
                }
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {

                if (objekat)
                {
                    objekat.Light();
                }
            }
        }

        else
        {
            objekat = null;
            upute.text = "";
        }


       

    }
}
