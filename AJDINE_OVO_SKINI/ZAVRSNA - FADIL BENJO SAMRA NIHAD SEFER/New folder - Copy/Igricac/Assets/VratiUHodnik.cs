using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VratiUHodnik : MonoBehaviour
{
    public void vratiMeUHodnik()
    {
        SceneManager.LoadScene("Igra");
    }
}
