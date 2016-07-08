using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    public static float timeCountUp = 0; //Pelaajalle näkyvä laskuri
    private static float startDelayTime = 0; //Pelaajalle näkymätön laskuri

    public static Text timerText;
    public static bool Cleared = false;


	void Start ()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>(); //Tulostetaan linkitettyyn textiin
    }

    public static void StartGame()
    {
        Cleared = false;
        timeCountUp = 0;
        startDelayTime = 0;
    }

    public static void EndGame()
    {
        Cleared = true; //Kun kaikki kortit on löydetty, niin ajastin pysähtyy
    }

    void Update()
    {
        startDelayTime += Time.deltaTime;

        if (startDelayTime <= 3)
        {
//            Debug.Log(startDelayTime);
        }
/*
        if (startDelayTime > 1.5)
        {
            Destroy(GameObject.Find("Kuura"));
        }
        */

        if (Cleared == true)
        {
//            print(timeCountUp); //Tulostetaan Consoleen
            timerText.text = timeCountUp.ToString("f3"); //Määritellään aika printattavaksi textiin kolmella desimaalilla
        }
        else if (Cleared == false)
        {
            timerText.text = timeCountUp.ToString("f3");
            if (startDelayTime > 3)
            { 
                timeCountUp += Time.deltaTime; //Kun näkymätön laskuri on yli sekunnin, niin näkyvä laskuri lähtee rullaamaan
            }
        }

    }
}
