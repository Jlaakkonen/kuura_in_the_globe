using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShelfGameManager : GameManager
{
	//public static new ShelfManager manager;
	bool levelComplete;
	public static Transform destroyPoint;
	public static float xMinPoint, xMaxPoint;
	public static bool gyroOn = false;
	//int gyroValue = 0;
	Transform desPoint;
    static public Toggle gyroButton;
    public Canvas canvas;
    
    //Toggle gyroToggle;

    //Singleton check
    protected override void Awake()
    {
        //canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //gyroButton.onValueChanged.AddListener((delegate { this.GyroToggle(); }));
        //DontDestroyOnLoad(canvas);
        //Debug.Log("listener lisätty");

        gyroButton = GameObject.Find("GyroToggle").GetComponent<Toggle>();
        gyroButton.onValueChanged.AddListener((delegate { ShelfGameManager.GyroToggle(); }));

        if (ShelfGameManager.gyroOn == true)
        {
            gyroButton.isOn = true;
        }
        else
        {
            gyroButton.isOn = false;
        }

        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);

            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);

            Debug.Log("Destroy ShelfManager");
        }
    }

	public override void PlayerWin()
	{
		if (manager.completedLevels.Contains(currentLevel) == false)
		{
			completedLevels.Add(currentLevel);
            GlobalGameManager.GGM.bubbleWarehouseSave();
        }
	}
	public override void PlayerLose()
	{
		base.PlayerLose();
	}
	public override void CheckForWin(bool hasKisse)
	{
		/*if (hasKisse)
		{
			PlayerWin();
		}*/
	}

	public override void RestartLevel()
	{
        //Application.LoadLevel (Application.loadedLevel);
        //base.RestartLevel();
        //Time.timeScale = 1f;
        LoadLevel(currentLevel);

    }

	void OnLevelWasLoaded()
	{
		Time.timeScale = 1f;
	}
	public void LoadNextLevel()
	{
        //base.LoadNextLevel ();
        if (GameManager.manager.completedLevels.Contains(GameManager.manager.currentLevel) == true)
        {
            LoadLevel(currentLevel + 1);
        }
        else
        {
            //pistä joku popuppi tähän.
        }
	}

    
    static public void GyroToggle()
	{
        
        gyroButton = GameObject.Find ("GyroToggle").GetComponent<Toggle> ();
        
        if (gyroButton.isOn == true) 
		{
			gyroOn = true;
			Debug.Log ("Gyro Päällä");
		} 
		else if (gyroButton.isOn == false) 
		{
			gyroOn = false;
			Debug.Log ("Gyro Poissa Päältä");
		}
	}
	public bool ReturnToggle()
	{
		return gyroOn;
	}
}