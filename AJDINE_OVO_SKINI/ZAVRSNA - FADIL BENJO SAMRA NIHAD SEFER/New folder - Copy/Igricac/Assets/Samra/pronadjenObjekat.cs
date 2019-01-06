using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pronadjenObjekat : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
     

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.transform.name == "trazeniObjekt")
                {
                    GameObject go=GameObject.Find("trazeniObjekt");
                    Destroy(go);
                    GameObject.Find("Main Camera").SendMessage("Kraj");
                }
            }
        }
    }
}
