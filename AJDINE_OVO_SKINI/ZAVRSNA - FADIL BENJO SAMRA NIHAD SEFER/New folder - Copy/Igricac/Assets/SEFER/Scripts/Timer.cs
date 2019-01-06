using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public int vrijemeZaLevel;
    float vrijeme;
    public static int sekunde;
    public static int minute;
    public static bool vrijemeTrigger=false;
    Light hintLight;
    Text tekst;
    private bool hintShow = false;
	void Start () {
        vrijemeZaLevel = 0;
        minute = vrijemeZaLevel/60;
        sekunde = vrijemeZaLevel%60;
        vrijeme = vrijemeZaLevel;
        tekst = GetComponentInChildren<Text>();
        vrijemeTrigger = true;
        hintLight = GameObject.Find("HintLight").GetComponent<Light>();
        //image.enabled = false;
        //tekst.enabled = false;
    }
    void Update() {
        if (vrijemeTrigger)
        {
            if (!hintShow && vrijeme >= 300 && vrijeme <= 330)
            {
                // Pokazi hint
                Debug.Log("Prikazi hint");
                hintLight.enabled = true;
                hintShow = true;
            }
            if (vrijeme >= 240 && vrijeme <= 300)
                tekst.color = Color.red;
            vrijeme += Time.deltaTime;
            minute = (int)vrijeme / 60;
            sekunde = (int)vrijeme % 60;
            tekst.text = minute.ToString("00") + ":" + sekunde.ToString("00");
        }
	}
}
