using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class TouchControls : MonoBehaviour
{

    private CharacterMovementTile thePlayer;
    Vector3 pos;
    float speed = 3.0f;
    float timer = 0;
    bool rightButtonHeld = false;
    bool leftButtonHeld = false;
    bool upButtonHeld = false;
    bool downButtonHeld = false;
    public GameObject player;
    Animator anim;
    private bool waitOn = false;



    public void pressedRight(BaseEventData eventData)
    {
        rightButtonHeld = true;
    }
    public void notpressedRight(BaseEventData eventData)
    {
        rightButtonHeld = false;
    }

    public void pressedLeft(BaseEventData eventData)
    {
        leftButtonHeld = true;
    }
    public void notpressedLeft(BaseEventData eventData)
    {
        leftButtonHeld = false;
    }

    public void pressedUp(BaseEventData eventData)
    {
        upButtonHeld = true;
    }
    public void notpressedUp(BaseEventData eventData)
    {
        upButtonHeld = false;
    }

    public void pressedDown(BaseEventData eventData)
    {
        downButtonHeld = true;
    }
    public void notpressedDown(BaseEventData eventData)
    {
        downButtonHeld = false;
    }

    void Start()
    {
        anim = player.GetComponent<Animator>();
        thePlayer = FindObjectOfType<CharacterMovementTile>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (rightButtonHeld)
        {
            RightArrow();

        }

        else if (leftButtonHeld)
        {
            LeftArrow();

        }

        else if(upButtonHeld)
        {
            UpArrow();

        }

        else if(downButtonHeld)
        {
            DownArrow();

        }
        else if(!waitOn)
        {
            PlayerStay();
        }
    }

    public void RightArrow()
    {
        if (timer < 0)
        {
            timer = 0.3f;
            thePlayer.MovePlayerRight();
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", true);
            anim.SetBool("GoLeft", false);
        }

    }

    public void LeftArrow()
    {
        if (timer < 0)
        {
            timer = 0.3f;
            thePlayer.MovePlayerLeft();
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", true);
        }

    }

    public void UpArrow()
    {
        if (timer < 0)
        {
            timer = 0.3f;
            thePlayer.MovePlayerUp();
            anim.SetBool("GoUp", true);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", false);
        }


    }

    public void DownArrow()
    {
        if (timer < 0)
        {
            timer = 0.3f;
            thePlayer.MovePlayerDown();
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", true);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", false);
        }
    }

    public void PlayerStay()
    {
            StartCoroutine(WaitIdleAnimation());
            anim.SetBool("GoUp", false);
            anim.SetBool("GoDown", false);
            anim.SetBool("GoRight", false);
            anim.SetBool("GoLeft", false);
    }

    public IEnumerator WaitIdleAnimation()
    {
        waitOn = true;
        yield return new WaitForSeconds(1.1f);
        waitOn = false; 
    }
}