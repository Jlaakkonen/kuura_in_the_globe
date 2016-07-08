using UnityEngine;
using System.Collections;

public class OnDeathScreen : MonoBehaviour {

	public GameObject confuseimg;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{

			confuseimg.SetActive(true);
			Time.timeScale = 0;
		}
	}
	public void OnButtonClick ()
	{   
		confuseimg.SetActive(false);
		LabManager.manager.RestartLevel ();
		Time.timeScale = 1;
	}
}
