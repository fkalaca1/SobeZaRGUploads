using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public static bool lock_it;
    Transform player;
    public GameObject pauseMenu;

    void Start()
    {
        lock_it = true;
        player = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lock_it = !lock_it;
        }
        if (lock_it)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.GetComponent<FirstPersonController>().enabled = true;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<FirstPersonController>().enabled = false;
            pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        lock_it = true;
    }
    public static void Quit()
    {
        Timer.vrijemeTrigger = false;
        PlayerPrefs.SetInt("ScoreMinute", Timer.minute);
        PlayerPrefs.SetInt("ScoreSekunde", Timer.sekunde);
        //Set bool dal je predmet pronadjen
        PlayerPrefs.SetInt("Pronadjen", Trigger_Animation.pronadjen?1:0);
        //Load scene
        SceneManager.LoadScene("Igra");
    }
}
