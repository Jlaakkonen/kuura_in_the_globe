using UnityEngine;
using System.Collections;

public class startscript : MonoBehaviour {

	public GameObject layermanager;

	public void OnMouseDown(){ // start button script 
		if (this.gameObject.name == "start_button") {
			layermanager.GetComponent<LayerScript>().Layers();
//			this.gameObject.SetActive(false);
		}
	}
}
