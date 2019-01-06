using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PocetakIgreScript : MonoBehaviour
{
    public static bool daLiJeLogovan = false;

    public List<string> usernames;
    public List<string> passwords;
    public static string loggedInUsername;

    public GameObject PanelPocetni;
    public GameObject PanelLogIn;
    public GameObject PanelRangLista;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickLogInPanelPocetni()
    {
        PanelLogIn.SetActive(true);
        PanelPocetni.SetActive(false);
    }

    public void ClickRangListaPanelPocetni()
    {
        PanelRangLista.SetActive(true);
        PanelPocetni.SetActive(false);
    }

    public void ClickLogInPanelLogin()
    {
        ReadPlayers();
        if (areCredentialsValid())
        {
            Debug.Log("LOGOOVAAAN");
            daLiJeLogovan = true;
            SceneManager.LoadScene("Igra");
        }
        
    }

    public void ClickNazadPanelRangLista()
    {
        PanelPocetni.SetActive(true);
        PanelRangLista.SetActive(false);
    }

    public void ReadPlayers()
    {
        using (var reader = new StreamReader(@"./Assets/spisak_igraca.csv"))
        {
            usernames = new List<string>();
            passwords = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                usernames.Add(values[0]);
                passwords.Add(values[1]);
            }
        }
    }
    

    public bool areCredentialsValid()
    {
        string usernameText = "";
        string passwordText = "";
        List<InputField> inputFields = new List<InputField>();
        PanelLogIn.GetComponentsInChildren(inputFields);

        foreach (var x in inputFields)
        {
            if(x.name == "UsernameIF")
            {
                usernameText = x.text;
            } else if(x.name == "PasswordIF")
            {
                passwordText = x.text;
            }
        }

        if (PanelLogIn != null)
        {
            for (int i = 0; i < usernames.Count; i++)
            {
                if (usernames[i] == usernameText && passwords[i] == passwordText)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
