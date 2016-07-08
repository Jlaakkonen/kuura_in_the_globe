using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReturnToWorldSelect : MonoBehaviour {

    Button button;
    GameObject canvas;

	// Use this for initialization
	void Start ()
    {
        button = GetComponent<Button>();

        canvas = GameObject.Find("Canvas");
        
        button.onClick.AddListener(ReturnToWorld);
	}

    void ReturnToWorld()
    {
        
        Destroy(canvas);
        GameManager.manager.ReturnToWorldSelect();
    }
}
