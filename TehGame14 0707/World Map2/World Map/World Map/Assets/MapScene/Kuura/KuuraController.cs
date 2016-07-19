using UnityEngine;
using System.Collections;

public class KuuraController : MonoBehaviour
{

    private Animator kuuraAnimator;

//    private map_manager map;

    public Vector3 destination;
    float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
    float kuuraNopeus = 100;

    Vector3 startPosition;

    public Transform target;

    private bool Moving;

    public Vector3 offsetMax;
    public Vector3 offsetMin;

    public RectTransform recTrans;

    GameObject Kuura;

    Collider2D River; //Objektiin luotu tag


    // Use this for initialization
    void Start ()
    {
//        map = GameObject.Find("tilemap_parent").GetComponent<map_manager>();

        kuuraAnimator = GetComponent<Animator>();

        Kuura = GameObject.Find("Kuura");

        Kuura.transform.position = new Vector3(Kuura.transform.position.x, Kuura.transform.position.y, Kuura.transform.position.z);

        destination = Kuura.transform.position;

        Invoke("KuuraSuunta", 0F);

//        River = GameObject.Find("River").GetComponent<Collider2D>();

        //Vector2 min = recTrans.anchorMin;
        //min.x *= Screen.width;
        //min.y *= Screen.height;

        //min += recTrans.offsetMin;

        //Vector2 max = recTrans.anchorMax;
        //max.x *= Screen.width;
        //max.y *= Screen.height;

        //max += recTrans.offsetMax;

        //Debug.Log(min + " " + max);
    }

    void StartLerping()
    {
        Moving = true;
        lerpStartTime = Time.time;
        startPosition = Kuura.transform.position;
    }
	
    void KuuraSuunta()
    {
        float Randomi = Random.value;

        if (Randomi <= 0.25)
        {
            StartLerping();
            destination = new Vector3(Kuura.transform.position.x, Kuura.transform.position.y + kuuraNopeus, Kuura.transform.position.z);

//            kuuraAnimator.SetTrigger("KuuraYlös");
        }
        else if (Randomi < 0.5)
        {
            StartLerping();
            destination = new Vector3(Kuura.transform.position.x, Kuura.transform.position.y - kuuraNopeus, Kuura.transform.position.z);

//            kuuraAnimator.SetTrigger("KuuraAlas");
        }
        else if (Randomi < 0.75)
        {
            StartLerping();
            destination = new Vector3(Kuura.transform.position.x + kuuraNopeus, Kuura.transform.position.y, Kuura.transform.position.z);

//            kuuraAnimator.SetTrigger("KuuraOikea");
        }
        else if (Randomi <= 1)
        {
            StartLerping();
            destination = new Vector3(Kuura.transform.position.x - kuuraNopeus, Kuura.transform.position.y, Kuura.transform.position.z);

//            kuuraAnimator.SetTrigger("KuuraVasen");
        }

        Debug.Log("Randomi = " + Randomi);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {

//        kuuraAnimator.SetTrigger("KuuraAlas");

        if(Moving)
        {
            if (destination.y > Kuura.transform.position.y)
            {
                kuuraAnimator.SetTrigger("KuuraYlös");
            }
            else if (destination.y < Kuura.transform.position.y)
            {
                kuuraAnimator.SetTrigger("KuuraAlas");
            }
            else if (destination.x > Kuura.transform.position.x)
            {
                kuuraAnimator.SetTrigger("KuuraOikea");
            }
            else if (destination.x < Kuura.transform.position.x)
            {
                kuuraAnimator.SetTrigger("KuuraVasen");
            }

            float timeSinceStarted = Time.time - lerpStartTime;
            float percentageComplete = timeSinceStarted / 75F;
            Kuura.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);

//            Debug.Log("percentageComplete = " + percentageComplete);

            if (percentageComplete >= 0.03F)
            {
                Moving = false;
            }
        }
        else
        {
            Invoke("KuuraSuunta", 0F);
        }
	}

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "River")     //Toiminto kun hitboxit törmäävät
        {
            //Moving = false;
            //Invoke("KuuraSuunta", 0F);
        }
    }
}
