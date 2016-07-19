using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalManager : MonoBehaviour
{
    public static float winTime = CountUpTimer.timeCountUp;
    public static float[] ScoreArray = new float[10]; //Tuloslista
    public static int MagicDust; //Pistemäärä

    public static Text Score1Text;
    public static Text Score2Text;
//    public static Text Score3Text;

    public static Text AllMagicDust;

    public static void Start ()
    {
        
    }
	
	void Update ()
    {
	    
	}

    public static void MemoryGameSave() //Tallennetaan pelin tulokset
    {
        winTime = CountUpTimer.timeCountUp;
//        ScoreArray[0] = 0;
//        MagicDust = 0;
//        Score1 = winTime;
//        Score1Text = GameObject.Find("Score1").GetComponent<Text>();
//        Score1Text.text = ScoreArray[1].ToString("f3");
                
        for (int i = 0; i <= 4; i++)
        {
//            ScoreArray[2] = 2;

            if (winTime < ScoreArray[2]) //Tulostettavat tulokset, mikäli määritelty aikaraja ei ylity
            {
                ScoreArray[1] = winTime;

                Score1Text = GameObject.Find("Score1").GetComponent<Text>();
                Score1Text.text = ScoreArray[1].ToString("f3");             //Tulostetaan suoritusaika ylempään scoreen
                
                Debug.Log("Global Manager: Score 1 = " + ScoreArray[1]);
                Debug.Log("ScoreArray[1] = " + ScoreArray[1]);

            }

            if (winTime > ScoreArray[2]) //Tulostettavat tulokset, mikäli määritelty aikaraja ylittyy
            {
                ScoreArray[1] = winTime;

                
                

                Score1Text = GameObject.Find("Score1").GetComponent<Text>();
                Score1Text.text = ScoreArray[2].ToString("f3");             //Tulostetaan rikottava aikaraja ylempään scoreen

                Score2Text = GameObject.Find("Score2").GetComponent<Text>();
                Score2Text.text = ScoreArray[1].ToString("f3");             //Tulostetaan suoritusaika alempaan scoreen

//                Score3Text = GameObject.Find("Score3").GetComponent<Text>();
//                Score3Text.text = ScoreArray[i + 2].ToString("f3");


                


                Debug.Log("Global Manager: Score 1 = " + ScoreArray[1]);
                Debug.Log("Global Manager: Score 2 = " + ScoreArray[2]);
            }

            PlayerPrefs.SetFloat("Score " + 1, ScoreArray[1]); //Tallennetaan tulokset tuloslistaan hakusanalla
//            PlayerPrefs.SetFloat("Score " + 2, ScoreArray[2]); //Tallennetaan tulokset tuloslistaan hakusanalla
        }



        if (winTime < ScoreArray[2]) //Saatavat pisteet, mikäli määritelty aikaraja ei ylity
        {
            if (LayerScript.triesLeft == 2) //Kaikki kolme yritystä jäljellä
            {
                MagicDust += 20 * 10; //Maksimipisteet
            }

            else if (LayerScript.triesLeft == 1) //Kaksi yritystä jäljellä
            {
                MagicDust += 20 * 5;
            }

            else if (LayerScript.triesLeft == 0) //Yksi yritys jäljellä
            {
                MagicDust += 20 * 2;
            }


            AllMagicDust = GameObject.Find("MagicDust").GetComponent<Text>();
            AllMagicDust.text = MagicDust.ToString("f0");

            Debug.Log("Global Manager: Magic Dust = " + MagicDust);
        }

        if (winTime > ScoreArray[2]) //Saatavat pisteet, mikäli määritelty aikaraja ylittyy
        {
            
                if (LayerScript.triesLeft == 2) //Kaikki kolme yritystä jäljellä
            {
                    MagicDust += 10 * 10;
                }

                else if (LayerScript.triesLeft == 1) //Kaksi yritystä jäljellä
            {
                    MagicDust += 10 * 5;
                }

                else if (LayerScript.triesLeft == 0) //Yksi yritys jäljellä
            {
                    MagicDust += 10 * 2; //Minimipisteet
                }

            AllMagicDust = GameObject.Find("MagicDust").GetComponent<Text>();
            AllMagicDust.text = MagicDust.ToString("f0");

            Debug.Log("Global Manager: Magic Dust = " + MagicDust);
        }

        PlayerPrefs.SetInt("Magic Dust ", MagicDust); //Tallennetaan pisteet



    }

    public static void MemoryGameLoad() //Ladataan edeltävät tulokset
    {
//        PlayerPrefs.DeleteAll();
        for (int i = 0; i <= 4; i++)
        {
            ScoreArray[2] = 2; //Määritellään aikaraja, jonka ylittyessä saadaan vähemmän pisteitä

            ScoreArray[1] = PlayerPrefs.GetFloat("Score " + 1); //Ladataan tuloslistan tulokset hakusanalla
            MagicDust = PlayerPrefs.GetInt("Magic Dust "); //Ladataan kerätyt pisteet

            Score1Text = GameObject.Find("Score1").GetComponent<Text>();
            Score1Text.text = ScoreArray[1].ToString("f3");             //Tulostetaan edeltävä tulos

            Score2Text = GameObject.Find("Score2").GetComponent<Text>();
            Score2Text.text = ScoreArray[2].ToString("f3");             //Tulostetaan määritelty aikaraja

//            Score3Text = GameObject.Find("Score3").GetComponent<Text>();
//            Score3Text.text = ScoreArray[i + 2].ToString("f3");


            AllMagicDust = GameObject.Find("MagicDust").GetComponent<Text>();
            AllMagicDust.text = MagicDust.ToString("f0"); //Tulostetaan pisteet
        }

        Debug.Log("ScoreArray[0] = " + ScoreArray[0]);

    }
}
