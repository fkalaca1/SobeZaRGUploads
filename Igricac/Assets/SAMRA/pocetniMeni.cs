using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pocetniMeni : MonoBehaviour
{
    public Button startButton;
    public string nazivScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        startButton.onClick.AddListener(startGame);
    }

    public void startGame()
    {
        SceneManager.LoadScene(nazivScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
