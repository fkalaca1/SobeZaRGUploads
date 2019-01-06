using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zavrsnaScena : MonoBehaviour
{
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Awake()
    {
        exit.onClick.AddListener(onExitClick);
    }

    void onExitClick()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
