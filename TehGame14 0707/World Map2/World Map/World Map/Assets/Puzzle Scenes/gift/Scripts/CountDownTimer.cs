using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static float timeCountDown = 3;

    public static Text CountDown;

	// Use this for initialization
	public static void Start ()
    {
//        CountDown = GameObject.Find("Timer2").GetComponent<Text>();
        timeCountDown = 4;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeCountDown >= 1)
        {
            timeCountDown -= Time.deltaTime;
            CountDown.text = timeCountDown.ToString("f1");
        }
        else
        {
            Destroy(GameObject.Find("Timer2"));
        }
	}
}
