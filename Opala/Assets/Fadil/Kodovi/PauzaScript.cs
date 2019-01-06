using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzaScript : MonoBehaviour
{
    public static bool daLiJePauziran = false;
    public static int usaoPuta = 1;
    public GameObject PanelPause;
    public GameObject PanelRangLista;

    public static bool nadjenItem1 = true;
    public static bool nadjenItem2 = true;
    public static bool nadjenItem3 = true;
    public static bool nadjenItem4 = true;
    public static bool nadjenItem5 = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(daLiJePauziran.Equals(true))
            {
                Nastavi();
            }
            else
            {
                Pauziraj();
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        //fale uslovi za items i fale uslovi za koja je soba
        if (Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene("Nihad");
        }
    }

    public void Nastavi()
    {
        PanelPause.SetActive(false);
        PanelRangLista.SetActive(false);
        Time.timeScale = 1f;
        daLiJePauziran = false;
    }
    public void Pauziraj()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
        daLiJePauziran = true;
    }


    public void ClickRangListaPanelPause()
    {
        PanelRangLista.SetActive(true);
        PanelPause.SetActive(false);
    }


    public void ClickNazadPanelRangLista()
    {
        PanelPause.SetActive(true);
        PanelRangLista.SetActive(false);
    }

    public void ClickLogOutPanelPause()
    {
        PocetakIgreScript.daLiJeLogovan = false;
        daLiJePauziran = false;
        SceneManager.LoadScene("Pocetak");
    }
}
