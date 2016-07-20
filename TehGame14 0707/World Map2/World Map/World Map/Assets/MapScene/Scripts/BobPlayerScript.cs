using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BobPlayerScript : MonoBehaviour
{
    private Animator BobPlayerAnimator;
    int BobDirection = 20;
    int OldBobDirection = 15;

    public static int DestinationButtonNumber;
    public static int DestinationButtonNumber2;
    private static int StandingButtonNumber = 0;
    private static int StandingButtonNumber2 = 1;

    //    private map_manager map;

    public static Vector3 destination;

    static float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
//    float BobNopeus = 10;

    static Vector3 startPosition;

    public Transform target;

    private static bool Moving;

    static GameObject BobPlayer;

    GameObject memoryGame;

    Collider2D Rakennus1; //Objektiin luotu tag
    Collider2D Rakennus2;

    Button Button1, Button2, Button3, Button4;

    // Use this for initialization
    void Start ()
    {
        BobPlayerAnimator = GetComponent<Animator>();

        memoryGame = GameObject.Find("memoryGame");     //Kohde johon kävellään

//        map = GameObject.Find("tilemap_parent").GetComponent<map_manager>();

        BobPlayer = GameObject.Find("BobPlayer");

        BobPlayer.transform.position = new Vector3(BobPlayer.transform.position.x, BobPlayer.transform.position.y, BobPlayer.transform.position.z);

        destination = BobPlayer.transform.position;

        Rakennus1 = GameObject.Find("memoryGame").GetComponent<Collider2D>();   //Viitataan luotuun tagiin

        //StandingButtonNumber = 0;

        Debug.Log("StandingButtonNumber = " + StandingButtonNumber);
        Debug.Log("StandingButtonNumber2 = " + StandingButtonNumber2);


        //Button1 = GameObject.Find("Tile").GetComponent<Button>();
        //Button2 = GameObject.Find("Tile (1)").GetComponent<Button>();
        //Button1 = GameObject.Find("Tile (2)").GetComponent<Button>();
        //Button1 = GameObject.Find("Tile (3)").GetComponent<Button>();

        //        Invoke("Movement", 2);


        // Instanciate the PathMap object:
    }

    public static void StartLerping()
    {
        Moving = true;
        lerpStartTime = Time.time;
        startPosition = BobPlayer.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        Movement();
        BobScale();

        if (Moving)
        {
            //if (destination.y > BobPlayer.transform.position.y)
            //{
            //    BobPlayerAnimator.SetTrigger("BobUp");
            //}
            //else if (destination.y < BobPlayer.transform.position.y)
            //{
            //    BobPlayerAnimator.SetTrigger("BobDown");
            //}
            //else if (destination.x > BobPlayer.transform.position.x)
            //{
            //    BobPlayerAnimator.SetTrigger("BobRight");
            //}
            //else if (destination.x < BobPlayer.transform.position.x)
            //{
            //    BobPlayerAnimator.SetTrigger("BobLeft");
            //}

            float timeSinceStarted = Time.time - lerpStartTime;

            float percentageComplete = timeSinceStarted / 0.5F;   //Kävelynopeus


            BobPlayer.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);    //Muutetaan Bobin sijaintia kartan Lerp-vektoreilla.

//            Debug.Log("percentageComplete = " + percentageComplete);
            if (percentageComplete >= 1.0F)
            {
                Moving = false;
                StandingButtonNumber = DestinationButtonNumber;
                StandingButtonNumber2 = DestinationButtonNumber2;//Muutetaan seisomisobjektin arvo kohdeobjektin arvoksi
                Debug.Log("StandingButtonNumber = " + StandingButtonNumber);
                Debug.Log("StandingButtonNumber2 = " + StandingButtonNumber2);
            }
        }
    }

    //void OnMouseDown()
    //{
    //    if (Input.mousePosition == Target.transform.position)
    //    {
    //        BobPlayerAnimator.SetTrigger("BobDown");
    //        StartLerping();
    //        Moving = true;
    //        destination = new Vector3(Target.transform.position.x, Target.transform.position.y);    //Kävellään kohdeobjektiin
    //    }
    //}

    void Movement()     //Liikutaan nuolinäppäimillä, ei nyt käytössä
    {
        

        float dT = Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))       //Liikutaan oikealle
        {
            BobDirection = 0;

            //transform.Translate(Vector3.right * 8f * dT);
            
            //            BobPlayerAnimator.SetTrigger("BobRight");
        }

        else if (Input.GetKey(KeyCode.LeftArrow))   //Liikutaan vasemmalle
        {
            BobDirection = 1;

            //transform.Translate(Vector3.left * 8f * dT);
            
            //            BobPlayerAnimator.SetTrigger("BobLeft");
        }

        else if (Input.GetKey(KeyCode.UpArrow))     //Liikutaan ylös
        {
            BobDirection = 2;

            //transform.Translate(Vector3.up * 8f * dT);
            
            //            BobPlayerAnimator.SetTrigger("BobUp");
        }

        else if (Input.GetKey(KeyCode.DownArrow))   //Liikutaan alas
        {
            BobDirection = 3;

            //transform.Translate(Vector3.down * 8f * dT);
            
            //            BobPlayerAnimator.SetTrigger("BobDown");
        }

        //if (BobDirection == OldBobDirection)
        //{
            
        //}
        //else
        //{
        //    if (BobDirection == 0)
        //    {
        //        BobPlayerAnimator.SetTrigger("BobRight");
        //        StartLerping();
        //        Moving = true;
        //        destination = new Vector3(BobPlayer.transform.position.x + BobNopeus, BobPlayer.transform.position.y);
        //    }
        //    else if (BobDirection == 1)
        //    {
        //        BobPlayerAnimator.SetTrigger("BobLeft");
        //        StartLerping();
        //        Moving = true;
        //        destination = new Vector3(BobPlayer.transform.position.x - BobNopeus, BobPlayer.transform.position.y);
        //    }
        //    else if (BobDirection == 2)
        //    {
        //        BobPlayerAnimator.SetTrigger("BobUp");
        //        StartLerping();
        //        Moving = true;
        //        destination = new Vector3(BobPlayer.transform.position.x, BobPlayer.transform.position.y + BobNopeus);
        //    }
        //    else if (BobDirection == 3)
        //    {
        //        BobPlayerAnimator.SetTrigger("BobDown");
        //        StartLerping();
        //        Moving = true;
        //        destination = new Vector3(BobPlayer.transform.position.x, BobPlayer.transform.position.y - BobNopeus);
        //    }
        //}

        //OldBobDirection = BobDirection;
    }

    public static void CheckNeighbour()     //Liikutaan vain yhtä suurempiin tai pienempiin arvoihin
    {
        if ((StandingButtonNumber + 1 == DestinationButtonNumber || StandingButtonNumber - 1 == DestinationButtonNumber || StandingButtonNumber == DestinationButtonNumber) && ( StandingButtonNumber2 + 1 == DestinationButtonNumber2 || StandingButtonNumber2 - 1 == DestinationButtonNumber2 || StandingButtonNumber2 == DestinationButtonNumber2))
        {
            StartLerping();
        }
        else
        {

        }
    }

    void BobScale()     //Skaalataan Bobia perspektiivin mukaan
    {
        gameObject.transform.localScale = new Vector2 (Mathf.Abs(gameObject.transform.position.y * 0.1F), Mathf.Abs(gameObject.transform.position.y * 0.1F));
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Rakennus1")     //Toiminto kun hitboxit törmäävät
        {
            Application.LoadLevel("GameScene");     //Mennään muistipeliin
        }
    }
}
