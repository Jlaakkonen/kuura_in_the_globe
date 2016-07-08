using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GlobalGameManager : MonoBehaviour
{
    //Do global functions
    public static GlobalGameManager GGM;
    public int gameSelectScene;
    public int[] gameScenes;
    int currentGame;
    public List<int> completedGames;



    //Pelienomat

    //Mappi muuttujat
    float ukkoX = 0.0f;
    float ukkoY = 0.0f;

    //BWH:n omat muuttujat
    int[] bwhStars = new int[200];
    List<int> bwhcompletedLevels = new List<int>();
    List<int> completetlevels;

    //Singleton check
    public void Awake()
    {
        if (GGM == null)
        {
            DontDestroyOnLoad(gameObject);
            GGM = this;
        }
        else if (GGM != this)
        {
            Destroy(gameObject);
        }
    }

    public void GoToGameSelect()
    {
        SceneManager.LoadScene(gameSelectScene);
    }

    public void StartGame(int gameIndex)
    {
        currentGame = gameIndex;
        SceneManager.LoadScene(gameScenes[gameIndex]);
    }

    public void CompleteCurrentGame()
    {
        completedGames.Add(currentGame);
    }

	public void StartMapScene()
	{
		SceneManager.LoadScene ("map_scene");
    }

    public void mappiLoad()
    {
        ukkoX = PlayerPrefs.GetFloat("ukkoX");
        ukkoY = PlayerPrefs.GetFloat("ukkoY");
    }

    public void mappiSave()
    {
        PlayerPrefs.SetFloat("ukkoX", ukkoX);
        PlayerPrefs.SetFloat("ukkoY", ukkoY);
    }

    public void bubbleWarehouseLoad()
    {
        for (int i = 0; i <= 100; i++)
        {
            GameManager.levelStars[i] = PlayerPrefs.GetInt("stars"+i);
        }
        for (int i = 0; i<= 20; i++)
        {

            bwhcompletedLevels.Add(PlayerPrefs.GetInt("levels" + i));

            if (bwhcompletedLevels.Contains(i))
            {
                GameManager.manager.completedLevels.Add(i);
            }
        } 
    }

    public void bubbleWarehouseSave()
    {
        bwhStars = GameManager.levelStars;
        bwhcompletedLevels = GameManager.manager.completedLevels;
        

        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("stars"+i, bwhStars[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (GameManager.manager.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("levels" + i, i);
                Debug.Log(bwhcompletedLevels[i]);
            }
        }
    }
}
