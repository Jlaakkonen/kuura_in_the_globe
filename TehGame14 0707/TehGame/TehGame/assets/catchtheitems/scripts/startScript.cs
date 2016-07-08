using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class startScript : MonoBehaviour {

    Image Star;
    public int starNumber;
    public int buttonNumber;

	// Use this for initialization
	void Start () {

        ChecKStars();
    }

    void ChecKStars()
    {
        Star = GetComponent<Image>();
        
        //Star.color = Color.white;
        Debug.Log(starNumber);

        if (GameManager.levelStars[buttonNumber] >= starNumber)
        {
            Star.color = Color.white;
            Debug.Log("varjattu");
        }
        else
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
       // ChecKStars();
	
	}


}
