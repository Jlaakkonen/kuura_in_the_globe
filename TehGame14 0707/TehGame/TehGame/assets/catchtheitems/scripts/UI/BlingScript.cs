using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class BlingScript : MonoBehaviour {

    static GameObject Bling;
    Vector3 destination;
    static Vector3 startPosition;
    public static float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
    public static bool moving;
    // Use this for initialization
    void Start () {

        //Bling = GetComponent<Image>();

        /*destination = new Vector3(Bling.transform.position.x, Bling.transform.position.y -100, Bling.transform.position.z);
        startPosition = new Vector3(Bling.transform.position.x, Bling.transform.position.y, Bling.transform.position.z);

        float timeSinceStarted = Time.time - lerpStartTime;
        float percentageComplete = timeSinceStarted / 1.5f;
        Debug.Log(percentageComplete);
        Bling.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
        */
    }

    public void BlingBling()
    {
        Bling = gameObject;

        destination = new Vector3(Bling.transform.position.x, Bling.transform.position.y - 50, Bling.transform.position.z);
        startPosition = new Vector3(Bling.transform.position.x, Bling.transform.position.y, Bling.transform.position.z);

        /*float timeSinceStarted = Time.time - lerpStartTime;
        float percentageComplete = timeSinceStarted / 1.5f;
        Debug.Log(percentageComplete);
        Bling.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);*/
    }

    public static void StartLerping()
    {
        moving = true;
        lerpStartTime = Time.time;
        startPosition = Bling.transform.position;

    }

    void fixedUpdate()
    {

        if (moving)
        {

            float timeSinceStarted = Time.time - lerpStartTime;
            float percentageComplete = timeSinceStarted / 1.5f;
            Debug.Log(percentageComplete);
            Bling.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
            //Debug.Log(tausta.transform.position);
            if (percentageComplete >= 1.0f)
            {
                moving = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	

	}
}
