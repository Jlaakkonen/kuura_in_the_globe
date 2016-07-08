using UnityEngine;
using System.Collections;

public class ChooseLevel : MonoBehaviour
{


	public void ChangeToScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
	}
}
