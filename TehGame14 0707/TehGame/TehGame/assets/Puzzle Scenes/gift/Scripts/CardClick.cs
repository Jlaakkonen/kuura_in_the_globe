using UnityEngine;
using System.Collections;

public class CardClick : MonoBehaviour
{

    public Sprite emptySprite;

    public GameObject layerManager;

//    bool lmbDisabled = false; //http://answers.unity3d.com/questions/699507/disableenable-mouseclick.html
    int counter = 0;

    public float x, y;
    void OnMouseDown() //save x and y locations of the cards when clicked on and send them to the click function 
    {
        if (this.gameObject.name == "card 0 0(Clone)")
        {
            x = 0;
            y = 0;
//            Debug.Log("CardClicks: x = 0, y = 0");
//            this.gameObject.SetActive(false);

/*
            counter++;
            if (counter < 3)
            {
                lmbDisabled = true;
                //counter = 0;
            }
            else if (counter == 3)
            {
                this.lmbDisabled = false;
                counter = 0;
            }
  */          
            
            click();
        }
             
        else if (this.gameObject.name == "card 0 2(Clone)") {
            x = 0;
            y = 2;
            click();
//            Debug.Log("CardClicks: x = 0, y = 2");
        }
        else if (this.gameObject.name == "card 0 4(Clone)") {
            x = 0;
            y = 4;
            click();
//            Debug.Log("CardClicks: x = 0, y = 4");
        }
        else if (this.gameObject.name == "card 0 6(Clone)") {
            x = 0;
            y = 6;
            click();
//            Debug.Log("CardClicks: x = 0, y = 6");
        }
        else if (this.gameObject.name == "card 0 8(Clone)") {
            x = 0;
            y = 8;
            click();
//            Debug.Log("CardClicks: x = 0, y = 8");
        }
        else if (this.gameObject.name == "card 0 10(Clone)")
        {
            x = 0;
            y = 10;
            click();
//            Debug.Log("CardClicks: x = 0, y = 10");
        }
        else if (this.gameObject.name == "card 2 0(Clone)") {
            x = 2;
            y = 0;
            click();
//            Debug.Log("CardClicks: x = 2, y = 0");
        }
        else if (this.gameObject.name == "card 2 2(Clone)") {
            x = 2;
            y = 2;
            click();
//            Debug.Log("CardClicks: x = 2, y = 2");
        }
        else if (this.gameObject.name == "card 2 4(Clone)") {
            x = 2;
            y = 4;
            click();
//            Debug.Log("CardClicks: x = 2, y = 4");
        }
        else if (this.gameObject.name == "card 2 6(Clone)") {
            x = 2;
            y = 6;
            click();
//            Debug.Log("CardClicks: x = 2, y = 6");
        }
        else if (this.gameObject.name == "card 2 8(Clone)") {
            x = 2;
            y = 8;
            click();
//            Debug.Log("CardClicks: x = 2, y = 8");
        }
        else if (this.gameObject.name == "card 2 10(Clone)")
        {
            x = 2;
            y = 10;
            click();
//            Debug.Log("CardClicks: x = 2, y = 10");
        }
        else if (this.gameObject.name == "card 4 0(Clone)") {
            x = 4;
            y = 0;
            click();
//            Debug.Log("CardClicks: x = 4, y = 0");
        }
        else if (this.gameObject.name == "card 4 2(Clone)") {
            x = 4;
            y = 2;
            click();
//            Debug.Log("CardClicks: x = 4, y = 2");
        }
        else if (this.gameObject.name == "card 4 4(Clone)") {
            x = 4;
            y = 4;
            click();
//            Debug.Log("CardClicks: x = 4, y = 4");
        }
        else if (this.gameObject.name == "card 4 6(Clone)") {
            x = 4;
            y = 6;
            click();
//           Debug.Log("CardClicks: x = 4, y = 6");
        }
        else if (this.gameObject.name == "card 4 8(Clone)") {
            x = 4;
            y = 8;
            click();
//            Debug.Log("CardClicks: x = 4, y = 8");
        }
        else if (this.gameObject.name == "card 4 10(Clone)")
        {
            x = 4;
            y = 10;
            click();
//            Debug.Log("CardClicks: x = 4, y = 10");
        }
        else if (this.gameObject.name == "card 6 0(Clone)") {
            x = 6;
            y = 0;
            click();
//            Debug.Log("CardClicks: x = 6, y = 0");
        }
        else if (this.gameObject.name == "card 6 2(Clone)") {
            x = 6;
            y = 2;
            click();
//            Debug.Log("CardClicks: x = 6, y = 2");
        }
        else if (this.gameObject.name == "card 6 4(Clone)") {
            x = 6;
            y = 4;
            click();
//            Debug.Log("CardClicks: x = 6, y = 4");
        }
        else if (this.gameObject.name == "card 6 6(Clone)") {
            x = 6;
            y = 6;
            click();
//            Debug.Log("CardClicks: x = 6, y = 6");
        }
        else if (this.gameObject.name == "card 6 8(Clone)") {
            x = 6;
            y = 8;
            click();
//            Debug.Log("CardClicks: x = 6, y = 8");
        }
        else if (this.gameObject.name == "card 6 10(Clone)")
        {
            x = 6;
            y = 10;
            click();
//            Debug.Log("CardClicks: x = 6, y = 10");
        }
        else if (this.gameObject.name == "card 8 0(Clone)") {
            x = 8;
            y = 0;
            click();
//            Debug.Log("CardClicks: x = 8, y = 0");
        }
        else if (this.gameObject.name == "card 8 2(Clone)") {
            x = 8;
            y = 2;
            click();
//            Debug.Log("CardClicks: x = 8, y = 2");
        }
        else if (this.gameObject.name == "card 8 4(Clone)") {
            x = 8;
            y = 4;
            click();
//            Debug.Log("CardClicks: x = 8, y = 4");
        }
        else if (this.gameObject.name == "card 8 6(Clone)") {
            x = 8;
            y = 6;
            click();
//            Debug.Log("CardClicks: x = 8, y = 6");
        }
        else if (this.gameObject.name == "card 8 8(Clone)") {
            x = 8;
            y = 8;
            click();
//            Debug.Log("CardClicks: x = 8, y = 8");
        }
        else if (this.gameObject.name == "card 8 10(Clone)")
        {
            x = 8;
            y = 10;
            click();
//            Debug.Log("CardClicks: x = 8, y = 10");
        }
        else if (this.gameObject.name == "card 10 0(Clone)")
        {
            x = 10;
            y = 0;
            click();
//            Debug.Log("CardClicks: x = 10, y = 0");
        }
        else if (this.gameObject.name == "card 10 2(Clone)")
        {
            x = 10;
            y = 2;
            click();
//            Debug.Log("CardClicks: x = 10, y = 2");
        }
        else if (this.gameObject.name == "card 10 4(Clone)")
        {
            x = 10;
            y = 4;
            click();
//            Debug.Log("CardClick:s x = 10, y = 4");
        }
        else if (this.gameObject.name == "card 10 6(Clone)")
        {
            x = 10;
            y = 6;
            click();
//            Debug.Log("CardClicks: x = 10, y = 6");
        }
        else if (this.gameObject.name == "card 10 8(Clone)")
        {
            x = 10;
            y = 8;
            click();
//            Debug.Log("CardClicks: x = 10, y = 8");
        }
        else if (this.gameObject.name == "card 10 10(Clone)")
        {
            x = 10;
            y = 10;
            click();
//            Debug.Log("CardClicks: x = 10, y = 10");
        }
    }

void click() // call click action function
{
    GameObject clickedCard = this.gameObject;
    layerManager = GameObject.Find("LayerManager");
    layerManager.GetComponent<LayerScript>().ClickAction(clickedCard, (int)x, (int)y); //kun x ja y floatteja, niin edessä oltava sulkeissa int
    }
}

