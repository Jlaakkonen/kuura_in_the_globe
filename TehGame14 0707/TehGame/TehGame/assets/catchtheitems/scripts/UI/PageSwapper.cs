using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class PageSwapper : MonoBehaviour {

    //Button button;
    GameObject muutNapit;
    static public int page;
    public int suunta;
    float startTime;
    Vector2 startPos;
    bool couldBeSwipe;
    float comfortZone;
    float minSwipeDist;
    float maxSwipeTime;
    public Button button;
    GameObject tausta;
    bool moving;

    public Vector3 destination;
    float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;

    Vector3 startPosition;

    public Transform target;



    // Use this for initialization
    void Start () {
        

        button = GetComponent<Button>();
        button.onClick.AddListener(buttonpressed);
        tausta = GameObject.Find("Image");
        tausta.transform.position = new Vector3(tausta.transform.position.x, tausta.transform.position.y, tausta.transform.position.z);
        destination = tausta.transform.position;
        //button = GetComponent<Button>();
        //button.onClick.AddListener(buttonpressed);

    }

    void buttonpressed()
    {
        //destination = new Vector3(tausta.transform.position.x * 1 * Time.deltaTime, tausta.transform.position.y, tausta.transform.position.z);

        if (suunta == 0)
        {
            StartLerping();
            destination = new Vector3(tausta.transform.position.x + Screen.width, tausta.transform.position.y, tausta.transform.position.z);
            Debug.Log(destination);
            moving = true;
            //tausta.transform.position = Vector3.Lerp(tausta.transform.position, destination, 0.5f * Time.deltaTime);
            //Vector3.Lerp((tausta.transform.position.x * 1 * Time.deltaTime)+Screen.width, tausta.transform.position.y, tausta.transform.position.z,);
            pastLevels();
            Debug.Log(Screen.width);
            Debug.Log(suunta);
        }
        else if (suunta == 1)
        {

            //Työnalla.
            /*
            //target = new Vector3(tausta.transform.position.x * 1, tausta.transform.position.y, tausta.transform.position.z);
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
            private Vector3 velocity = new Vector3(0, 0, 0);
            Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            nextLevels();
            tausta.transform.position = new Vector3(tausta.transform.position.x * 1, tausta.transform.position.y, tausta.transform.position.z); 
           */
            StartLerping();
            destination = new Vector3(tausta.transform.position.x - Screen.width, tausta.transform.position.y, tausta.transform.position.z);
            Debug.Log(Screen.width);
            Debug.Log(destination);
            moving = true;
            //tausta.transform.position = Vector3.Lerp(tausta.transform.position, destination, 0.5f * Time.deltaTime);
            //tausta.transform.position = new Vector3(tausta.transform.position.x * 1 * Time.deltaTime, tausta.transform.position.y, tausta.transform.position.z);
            nextLevels();
            Debug.Log(suunta);
        }
        else if (suunta == 2)
        {

        }
        else if (suunta == 3)
        {

        }
    }
    void pastLevels()
    {
        
        page--;
    }

    void nextLevels()
    {
        page++;
        Debug.Log(page);
    }

    void StartLerping()
    {
        moving = true;
        lerpStartTime = Time.time;
        startPosition = tausta.transform.position;
        
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (moving)
        {

            float timeSinceStarted = Time.time - lerpStartTime;
            float percentageComplete = timeSinceStarted/1.5f;
            Debug.Log(percentageComplete);
            tausta.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
            //Debug.Log(tausta.transform.position);
            if (percentageComplete >= 1.0f)
            {
                moving = false;
            }
        }

        
        
        /* if (Input.touchCount > 0)
         {
             var touch = Input.touches[0];

             switch (touch.phase)
             {
                 case TouchPhase.Began:
                     couldBeSwipe = true;
                     startPos = touch.position;
                     startTime = Time.time;
                     break;

                 case TouchPhase.Moved:
                     if (Mathf.Abs(touch.position.y - startPos.y) > comfortZone)
                     {
                         couldBeSwipe = false;
                     }
                     break;

                 case TouchPhase.Stationary:
                     couldBeSwipe = false;
                     break;

                 case TouchPhase.Ended:
                     var swipeTime = Time.time - startTime;
                     var swipeDist = (touch.position - startPos).magnitude;

                     if (couldBeSwipe&&(swipeTime < maxSwipeTime)&&(swipeDist > minSwipeDist))
                     {
                         // It's a swiiiiiiiiiiiipe!
                         var swipeDirection = Mathf.Sign(touch.position.y - startPos.y);

                         // Do something here in reaction to the swipe.

                         GameManager.manager.LoadLevel(0);

                     }
                     break;
     }
 }
    */
    }
}
