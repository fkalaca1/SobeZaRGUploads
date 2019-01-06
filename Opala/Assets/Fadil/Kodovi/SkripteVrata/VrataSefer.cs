using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VrataSefer : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionStay(Collision collision)
    {
        //fale uslovi za items i fale uslovi za koja je soba
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Sefer");
        }
    }
}
