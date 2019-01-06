using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charController : MonoBehaviour
{
    public float speed = 10.0F;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown(KeyCode.M)) Cursor.lockState = CursorLockMode.None;

    }
}
