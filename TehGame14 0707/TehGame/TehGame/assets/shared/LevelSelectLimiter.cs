using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class LevelSelectLimiter : MonoBehaviour {

    public int buttonLevel;
    Button button;
    bool initialized = false;
    private Canvas canvas;
    private Toggle toggle;
    Image[] stars;
    

    //Checks levels if OnLevelWasLoaded was not called
    void Start ()
    {

//        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        
//        canvas.enabled = true;

        


        //toggle = GameObject.Find("GyroToggle").GetComponent<Toggle>();
        //toggle.onValueChanged.AddListener((delegate { ShelfGameManager.GyroToggle(); }));

        CheckLevels();
        
        /*if (ShelfGameManager.gyroOn == true)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        if (initialized == false)
        {
            CheckLevels();
        }*/
    }

    void OnLevelWasLoaded(int level)
    {
        CheckLevels();
    }
    void loadFrigginLevel ()
    {
//        canvas.enabled = false;
        GameManager.manager.LoadLevel(buttonLevel);
    }

    //Creates buttons and checks if this level is playable
    void CheckLevels()
    {

        GlobalGameManager.GGM.bubbleWarehouseLoad();
        /* If OnClick is assigned through the inspector,
         * the reference is lost upon scene load
         * So it's done through code */

        button = GetComponent<Button>();


        button.onClick.AddListener(loadFrigginLevel); //Adds OnClick to button
        //Debug.Log("nappula listenerit laitettu");
        gameObject.SetActive(false);



        //Debug.Log(LabManager.manager);

        //The first level is always shown regardless of its completetion
        if (GameManager.manager.completedLevels.Any() == false && buttonLevel == 0)
        {
            gameObject.SetActive(true);
        }
        //Checks if this or the previous level is completed, if previous is completed check if next level exists
        if (GameManager.manager.completedLevels.Contains(buttonLevel) ||
            GameManager.manager.completedLevels.Contains(buttonLevel - 1) && buttonLevel < GameManager.manager.levelIndex.Length)
        {
            gameObject.SetActive(true);
        }
        initialized = true;


        /*stars = gameObject.GetComponentsInChildren<Image>();
        Debug.Log(stars);


     
            if (gameObject.activeSelf == true)
        {
            Debug.Log(GameManager.levelStars[buttonLevel]);
            for (int y = 0; y <= stars.Length; y++)
            {
                Debug.Log(GameManager.levelStars + "banana");
                if (GameManager.levelStars[y] == 1) ;
                {
                    stars[y].color = Color.white;
                    Debug.Log(y);
                }
                
            }
        }*/

   }
}
