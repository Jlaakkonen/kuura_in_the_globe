using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Button Button;

    public int ButtonNumber;
    public int ButtonNumber2;

    static GameObject BobPlayer;

    // Use this for initialization
    void Start ()
    {
        Button = gameObject.GetComponent<Button>();

        Button.onClick.AddListener(() => MoveHere());

        BobPlayer = GameObject.Find("BobPlayer");
    }

    // Update is called once per frame
    void Update ()
    {
	    
	}

    public void OnMouseDown()
    {
        MoveHere();

        //if (this.Button.name == "Exit")
        //{
        //    BobPlayer.transform.position = new Vector3(1.5F, -0.4F, -11.5F);
        //    Debug.Log(BobPlayer.transform.position);
        //}
    }

    void MoveHere ()
    {
        BobPlayerScript.DestinationButtonNumber = ButtonNumber;
        BobPlayerScript.DestinationButtonNumber2 = ButtonNumber2;

        BobPlayerScript.CheckNeighbour();   //Verrataan kohdeobjektin arvoa lähtöobjektin arvoon
        BobPlayerScript.destination = gameObject.transform.position;    //Liikutetaan pelaajaobjekti klikattuun objektiin
        BobPlayerScript.destination.y = BobPlayerScript.destination.y + 1;      //Nostetaan Bob buttonia ylemmäs
    }
}




//public void OnMouseDown()
//{ // start button script 
//    if (this.gameObject.name == "start_button")
//    {
//        layermanager.GetComponent<LayerScript>().Layers();
//        //			this.gameObject.SetActive(false);
//    }
//}
