using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour {
	
	public void OnButtonClick ()
	{
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;
		//Redo to UI function
		//Pauseimg.SetActive(false);
	}
}
